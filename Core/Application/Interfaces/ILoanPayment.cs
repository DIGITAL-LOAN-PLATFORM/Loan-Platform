using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ILoanPayment
    {
        Task<LoanPayment> CreateLoanPayment(CreateLoanPaymentDTO dto);
        Task<LoanPayment> GetLoanPaymentByIdAsync(int id);
        Task<List<LoanPayment>> GetAllLoanPaymentAsync();
    }
}
