using Application.DTO;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services.PaymentModalities
{
    public class PaymentModalityService : IPaymentModalityService
    {
        private readonly IPaymentModality _paymentModality;

        public PaymentModalityService(IPaymentModality paymentModality)
        {
            _paymentModality = paymentModality;
        }

        public async Task<List<PaymentModality>> GetAllAsync()
        {
            return await _paymentModality.GetAllAsync();
        }

        public async Task<PaymentModality> GetByIdAsync(int id)
        {
            return await _paymentModality.GetByIdAsync(id);
        }

        public async Task CreatePaymentModalityAsync(CreatePaymentModalityDTO createPaymentModalityDTO)
        {
            await _paymentModality.CreatePaymentModalityAsync(createPaymentModalityDTO);
        }

        public async Task UpdatePaymentModalityAsync(UpdatePaymentModalityDTO updatePaymentModalityDTO)
        {
            await _paymentModality.UpdatePaymentModalityAsync(updatePaymentModalityDTO);
        }

        public async Task DeletePaymentModalityAsync(int id)
        {
            await _paymentModality.DeletePaymentModalityAsync(id);
        }
    }
}
