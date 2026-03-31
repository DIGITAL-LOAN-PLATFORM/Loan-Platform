using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ILoanInstallment
    {
        Task<LoanInstallment> CreateLoanInstallment(LoanInstallmentDTO dto);
        Task<LoanInstallment> UpdateLoanInstallment(LoanInstallmentDTO dto);
        Task<LoanInstallment> GetLoanInstallmentByIdAsync(int id);
        Task<List<LoanInstallment>> GetAllLoanInstallmentAsync();
    }
}
