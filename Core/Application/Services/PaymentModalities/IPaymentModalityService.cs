using Application.DTO;
using Domain.Entities;

namespace Application.Services.PaymentModalities
{
    public interface IPaymentModalityService
    {
        Task<List<PaymentModality>> GetAllAsync();
        Task<PaymentModality> GetByIdAsync(int id);
        Task CreatePaymentModalityAsync(CreatePaymentModalityDTO createPaymentModalityDTO);
        Task UpdatePaymentModalityAsync(UpdatePaymentModalityDTO updatePaymentModalityDTO);
        Task DeletePaymentModalityAsync(int id);
    }
}
