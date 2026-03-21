using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PaymentModalityRepository : IPaymentModality
    {
        private readonly ApplicationDbContext _context;

        public PaymentModalityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PaymentModality>> GetAllAsync()
        {
            return await _context.PaymentModalities.ToListAsync();
        }

        public async Task<PaymentModality> GetByIdAsync(int id)
        {
            var paymentModality = await _context.PaymentModalities.FindAsync(id);
            return paymentModality ?? throw new KeyNotFoundException($"PaymentModality with ID {id} was not found.");
        }

        public async Task CreatePaymentModalityAsync(CreatePaymentModalityDTO createPaymentModalityDTO)
        {
            var paymentModality = new PaymentModality { Name = createPaymentModalityDTO.Name };
            await _context.PaymentModalities.AddAsync(paymentModality);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePaymentModalityAsync(UpdatePaymentModalityDTO updatePaymentModalityDTO)
        {
            var paymentModality = await _context.PaymentModalities.FindAsync(updatePaymentModalityDTO.Id);
            if (paymentModality != null)
            {
                paymentModality.Name = updatePaymentModalityDTO.Name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePaymentModalityAsync(int id)
        {
            var paymentModality = await _context.PaymentModalities.FindAsync(id);
            if (paymentModality != null)
            {
                _context.PaymentModalities.Remove(paymentModality);
                await _context.SaveChangesAsync();
            }
        }
    }
}
