using Application.Interfaces;
using Domain.Entities;
using Application.DTO;
using Application.Services.LoanInstallments;

namespace Application.Services.LoanDisbursments
{
    public class LoanDisbursmentServices : ILoanDisbursmentService
    {
        private readonly ILoanDisbursment _loanDisbursment;
        private readonly ILoanInstallmentService _installmentService;
        private readonly ILoanApplication _loanApplication;
        private readonly IPaymentModality _paymentModality;
        private readonly IAccount _accountRepository;

        public LoanDisbursmentServices(
            ILoanDisbursment loanDisbursment, 
            ILoanInstallmentService installmentService, 
            ILoanApplication loanApplication, 
            IPaymentModality paymentModality,
            IAccount accountRepository)
        {
            _loanDisbursment = loanDisbursment;
            _installmentService = installmentService;
            _loanApplication = loanApplication;
            _paymentModality = paymentModality;
            _accountRepository = accountRepository;
        }

        public async Task CreateLoanDisbursment(CreateLoanDisbursmentDTO dto)
        {
            var account = await _accountRepository.GetByIdAsync(dto.AccountId);
            if (account == null)
            {
                throw new Exception("Invalid funding account selected.");
            }

            if (account.Balance < dto.DisbursedAmount)
            {
                throw new Exception($"Insufficient balance. Account balance is {account.Balance:C}, but trying to disburse {dto.DisbursedAmount:C}.");
            }

            account.Balance -= dto.DisbursedAmount;
            
            await _accountRepository.UpdateAccountAsync(new UpdateAccountDTO 
            {
                Id = account.Id,
                Name = account.Name,
                Provider = account.Provider,
                Number = account.Number,
                Type = (int)account.Type,
                Balance = account.Balance
            });

            var disbursment = await _loanDisbursment.CreateLoanDisbursment(dto);

            // Fetch original duration and modality to determine installments
            var application = await _loanApplication.GetLoanApplicationByIdAsync(dto.LoanApplicationId);
            var duration = application?.Duration ?? 1;
            
            var modality = await _paymentModality.GetByIdAsync(dto.PaymentModalityId);
            var modalityName = modality?.Name?.ToLower() ?? "monthly";

            int numberOfInstallments = duration > 0 ? duration : 1;
            decimal installmentAmount = dto.TotalRepaymentAmount / numberOfInstallments;

            DateTime nextDueDate = dto.InterestClockStartDate;

            for (int i = 1; i <= numberOfInstallments; i++)
            {
                if (modalityName == "weekly")
                    nextDueDate = nextDueDate.AddDays(7);
                else if (modalityName == "yearly" || modalityName == "annually")
                    nextDueDate = nextDueDate.AddYears(1);
                else
                    nextDueDate = nextDueDate.AddMonths(1);

                await _installmentService.CreateLoanInstallmentAsync(new LoanInstallmentDTO
                {
                    LoanDisbursmentId = disbursment.Id,
                    DueDate = nextDueDate,
                    AmountDue = installmentAmount,
                    PenaltyAmount = 0,
                    AmountPaid = 0,
                    Status = "Pending",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
            }

            await _loanApplication.DisburseLoanApplicationAsync(dto.LoanApplicationId);
        }

        public async Task UpdateLoanDisbursment(UpdateLoanDisbursmentDTO updateLoanDisbursmentDTO)
        {
            await _loanDisbursment.UpdateLoanDisbursment(updateLoanDisbursmentDTO);
        }

        public async Task<LoanDisbursment> GetLoanDisbursment(int id)
        {
            return await _loanDisbursment.GetLoanDisbursmentByIdAsync(id);
        }

        public async Task<List<LoanDisbursment>> GetAllLoanDisbursments()
        {
            return await _loanDisbursment.GetAllLoanDisbursmentAsync();
        }

        public async Task DeleteLoanDisbursment(int id)
        {
            await _loanDisbursment.DeleteLoanDisbursment(new DeleteLoanDisbursmentDTO { Id = id });
        }
    }
}