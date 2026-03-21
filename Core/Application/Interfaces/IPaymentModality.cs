using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPaymentModality
    {
        Task<List<PaymentModality>> GetAllAsync();
        Task<PaymentModality> GetByIdAsync(int id);
        Task CreatePaymentModalityAsync(CreatePaymentModalityDTO createPaymentModalityDTO);
        Task UpdatePaymentModalityAsync(UpdatePaymentModalityDTO updatePaymentModalityDTO);
        Task DeletePaymentModalityAsync(int id);
    }
}
