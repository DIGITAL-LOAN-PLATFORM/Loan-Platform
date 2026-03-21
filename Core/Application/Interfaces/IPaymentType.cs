using Application.DTO;
using Domain.Entities;
namespace Application.Interfaces
{
    public interface IPaymentType
    {
        Task<List<PaymentType>> GetAllAsync();
        Task<PaymentType> GetByIdAsync(int id);
        Task CreatePaymentTypeAsync(CreatePaymentTypeDTO createPaymentTypeDTO);
        Task UpdatePaymentTypeAsync(UpdatePaymentTypeDTO updatePaymentTypeDTO);
        Task DeletePaymentTypeAsync(int id);
    }
}