using Application.DTO;
using Application.Interfaces;
using Application.Services.LoanInstallments;
using Domain.Entities;

namespace Application.Services.LoanPayments
{
    public class LoanPaymentService : ILoanPaymentService
    {
        private readonly ILoanPayment _loanPaymentRepository;
        private readonly ILoanInstallment _loanInstallmentRepository;
        private readonly IAccount _accountRepository;
        private readonly ILoanInstallmentService _loanInstallmentService;

        public LoanPaymentService(ILoanPayment loanPaymentRepository, ILoanInstallment loanInstallmentRepository, IAccount accountRepository, ILoanInstallmentService loanInstallmentService)
        {
            _loanPaymentRepository = loanPaymentRepository;
            _loanInstallmentRepository = loanInstallmentRepository;
            _accountRepository = accountRepository;
            _loanInstallmentService = loanInstallmentService;
        }

        public async Task<List<LoanPayment>> GetAllLoanPaymentAsync()
        {
            return await _loanPaymentRepository.GetAllLoanPaymentAsync();
        }

        public async Task<LoanPayment> ProcessLoanPaymentAsync(CreateLoanPaymentDTO dto)
        {
            var account = await _accountRepository.GetByIdAsync(dto.AccountId);
            if (account == null)
            {
                throw new Exception("Invalid receiving account selected.");
            }

            account.Balance += dto.Amount;
            
            await _accountRepository.UpdateAccountAsync(new UpdateAccountDTO 
            {
                Id = account.Id,
                Name = account.Name,
                Provider = account.Provider,
                Number = account.Number,
                Type = (int)account.Type,
                Balance = account.Balance
            });

            var payment = await _loanPaymentRepository.CreateLoanPayment(dto);

            // Update Installment mapping with overpayment handling
            var installment = await _loanInstallmentRepository.GetLoanInstallmentByIdAsync(dto.LoanInstallmentId);
            if (installment != null)
            {
                decimal remainingOwed = installment.AmountDue + installment.PenaltyAmount - installment.AmountPaid;
                decimal paymentAmount = dto.Amount;

                // Apply payment to current installment
                if (paymentAmount <= remainingOwed)
                {
                    installment.AmountPaid += paymentAmount;
                    
                    if (installment.AmountPaid >= installment.AmountDue + installment.PenaltyAmount)
                    {
                        installment.Status = "Paid";
                    }
                    else if (installment.AmountPaid > 0)
                    {
                        installment.Status = "Partial";
                    }

                    await _loanInstallmentRepository.UpdateLoanInstallment(new LoanInstallmentDTO 
                    {
                        Id = installment.Id,
                        AmountPaid = installment.AmountPaid,
                        PenaltyAmount = installment.PenaltyAmount,
                        Status = installment.Status
                    });
                }
                else
                {
                    // Pay off current installment completely
                    installment.AmountPaid += remainingOwed;
                    installment.Status = "Paid";
                    
                    await _loanInstallmentRepository.UpdateLoanInstallment(new LoanInstallmentDTO 
                    {
                        Id = installment.Id,
                        AmountPaid = installment.AmountPaid,
                        PenaltyAmount = installment.PenaltyAmount,
                        Status = installment.Status
                    });

                    // Apply excess to next installment
                    decimal excess = paymentAmount - remainingOwed;
                    var allInstallments = await _loanInstallmentService.GetLoanInstallmentsByDisbursementIdAsync(installment.LoanDisbursmentId);
                    var nextInstallment = allInstallments
                        .Where(i => i.DueDate > installment.DueDate && i.Status != "Paid")
                        .OrderBy(i => i.DueDate)
                        .FirstOrDefault();

                    if (nextInstallment != null)
                    {
                        // Apply excess directly to next installment
                        nextInstallment.AmountPaid += excess;
                        
                        decimal nextTotalOwed = nextInstallment.AmountDue + nextInstallment.PenaltyAmount;
                        if (nextInstallment.AmountPaid >= nextTotalOwed)
                        {
                            nextInstallment.Status = "Paid";
                        }
                        else if (nextInstallment.AmountPaid > 0)
                        {
                            nextInstallment.Status = "Partial";
                        }

                        await _loanInstallmentRepository.UpdateLoanInstallment(new LoanInstallmentDTO 
                        {
                            Id = nextInstallment.Id,
                            AmountPaid = nextInstallment.AmountPaid,
                            PenaltyAmount = nextInstallment.PenaltyAmount,
                            Status = nextInstallment.Status
                        });
                    }
                    // If no next installment, the excess remains in the account balance (already added above)
                }
            }

            return payment;
        }
    }
}
