using Application.DTO;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services.LoanApplications
{
    public class LoanApplicationService : ILoanApplicationService
    {
        //Dependency Injection
        private readonly ILoanApplication _loanApplication;

        //Constructor
        public LoanApplicationService(ILoanApplication loanApplication)
        {
            _loanApplication = loanApplication;
        }

        //GetAllLoanApplicationAsync
        public async Task<List<LoanApplication>> GetAllLoanApplicationAsync()
        {
            return await _loanApplication.GetAllLoanApplicationAsync();
        }

        //GetLoanApplicationByIdAsync
        public async Task<LoanApplication> GetLoanApplicationByIdAsync(int id)
        {
            return await _loanApplication.GetLoanApplicationByIdAsync(id);
        }

        //CreateLoanApplicationAsync
        public async Task CreateLoanApplicationAsync(CreateLoanApplicationDTO createLoanApplicationDTO)
        {
            await _loanApplication.CreateLoanApplicationAsync(createLoanApplicationDTO);
        }

        //UpdateLoanApplicationAsync
        public async Task UpdateLoanApplicationAsync(UpdateLoanApplicationDTO updateLoanApplicationDTO)
        {
            await _loanApplication.UpdateLoanApplicationAsync(updateLoanApplicationDTO);
        }

        //DeleteLoanApplicationAsync
        public async Task DeleteLoanApplicationAsync(int id)
        {
            await _loanApplication.DeleteLoanApplicationAsync(id);
        }

        //ApproveLoanApplicationAsync
        public async Task ApproveLoanApplicationAsync(int id)
        {
            await _loanApplication.ApproveLoanApplicationAsync(id);
        }

        //RejectLoanApplicationAsync
        public async Task RejectLoanApplicationAsync(int id)
        {
            await _loanApplication.RejectLoanApplicationAsync(id);
        }
    }
}