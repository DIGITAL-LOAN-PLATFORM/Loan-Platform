using Application.DTO;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services.LoanPayments
{
    public class LoanPaymentService : ILoanPaymentService
    {
        private readonly ILoanPayment _loanPaymentRepository;
        private readonly ILoanInstallment _loanInstallmentRepository;
        private readonly IAccount _accountRepository;

        public LoanPaymentService(ILoanPayment loanPaymentRepository, ILoanInstallment loanInstallmentRepository, IAccount accountRepository)
        {
            _loanPaymentRepository = loanPaymentRepository;
            _loanInstallmentRepository = loanInstallmentRepository;
            _accountRepository = accountRepository;
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

            // Update Installment mapping
            var installment = await _loanInstallmentRepository.GetLoanInstallmentByIdAsync(dto.LoanInstallmentId);
            if (installment != null)
            {
                installment.AmountPaid += dto.Amount;
                
                decimal totalOwed = installment.AmountDue + installment.PenaltyAmount;
                if (installment.AmountPaid >= totalOwed)
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

            return payment;
        }
    }
}
