using Application.DTO;
using Domain.Entities;

namespace Application.Services.LoanPayments
{
    public interface ILoanPaymentService
    {
        Task<LoanPayment> ProcessLoanPaymentAsync(CreateLoanPaymentDTO dto);
        Task<List<LoanPayment>> GetAllLoanPaymentAsync();
    }
}
