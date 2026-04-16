using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ILoanApplication
    {
        //Get All
        Task<List<LoanApplication>> GetAllLoanApplicationAsync();
        //Get By Id
        Task<LoanApplication> GetLoanApplicationByIdAsync(int id);
        //Create
        Task CreateLoanApplicationAsync(CreateLoanApplicationDTO createLoanApplicationDTO);
        //Update
        Task UpdateLoanApplicationAsync(UpdateLoanApplicationDTO updateLoanApplicationDTO);
        //Delete
        Task DeleteLoanApplicationAsync(int id);
        //Approve
        Task ApproveLoanApplicationAsync(int id);
        //Reject
        Task RejectLoanApplicationAsync(int id);
        //Disburse
        Task DisburseLoanApplicationAsync(int id);
    }
}