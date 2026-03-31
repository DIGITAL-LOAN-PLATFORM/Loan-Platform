using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ILoanDisbursment
    {
        Task<LoanDisbursment> CreateLoanDisbursment(CreateLoanDisbursmentDTO createLoanDisbursmentDTO);
        Task<LoanDisbursment> UpdateLoanDisbursment(UpdateLoanDisbursmentDTO updateLoanDisbursmentDTO);
        Task<LoanDisbursment> GetLoanDisbursmentByIdAsync(int id);
        Task<List<LoanDisbursment>> GetAllLoanDisbursmentAsync();
        Task<LoanDisbursment> DeleteLoanDisbursment(DeleteLoanDisbursmentDTO deleteLoanDisbursmentDTO);
    }
}