using Application.DTO;
using Domain.Entities;
namespace Application.Services.PaymentTypes
{
    public interface IPaymentTypeService
    {
        Task<List<PaymentType>> GetAllAsync();
        Task<PaymentType> GetByIdAsync(int id);
        Task CreatePaymentTypeAsync(CreatePaymentTypeDTO createPaymentTypeDTO);
        Task UpdatePaymentTypeAsync(UpdatePaymentTypeDTO updatePaymentTypeDTO);
        Task DeletePaymentTypeAsync(int id);
    }
}