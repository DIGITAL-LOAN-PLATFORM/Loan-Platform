using Application.Interfaces;
using Application.DTO;
using Domain.Entities;

namespace Application.Services.PaymentTypes
{
    public class PaymentTypeService : IPaymentTypeService
    {
       private readonly IPaymentType _paymentType;

       //Constructor
       public PaymentTypeService(IPaymentType paymentType)
       {
        _paymentType = paymentType;
       }

       public async Task<List<PaymentType>> GetAllAsync()
       {
        return await _paymentType.GetAllAsync();
       }

       public async Task<PaymentType> GetByIdAsync(int id)
       {
        return await _paymentType.GetByIdAsync(id);
       }

       public async Task CreatePaymentTypeAsync(CreatePaymentTypeDTO createPaymentTypeDTO)
       {
        await _paymentType.CreatePaymentTypeAsync(createPaymentTypeDTO);
       }

       public async Task UpdatePaymentTypeAsync(UpdatePaymentTypeDTO updatePaymentTypeDTO)
       {
        await _paymentType.UpdatePaymentTypeAsync(updatePaymentTypeDTO);
       }

       public async Task DeletePaymentTypeAsync(int id)
       {
        await _paymentType.DeletePaymentTypeAsync(id);
       }

    }
}