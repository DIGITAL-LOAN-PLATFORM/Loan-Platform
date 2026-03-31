using Application.DTO;
using Domain.Entities;

namespace Application.Services.LoanInstallments
{
    public interface ILoanInstallmentService
    {
        Task<LoanInstallment> CreateLoanInstallmentAsync(LoanInstallmentDTO dto);
        Task<LoanInstallment> UpdateLoanInstallmentAsync(LoanInstallmentDTO dto);
        Task<LoanInstallment> GetLoanInstallmentByIdAsync(int id);
        Task<List<LoanInstallment>> GetAllLoanInstallmentAsync();
    }
}
