using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories
{
    public class PaymentTypeRepository : IPaymentType
    {
        private readonly ApplicationDbContext _context;

        public PaymentTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<PaymentType>> GetAllAsync()
        {
            return await _context.PaymentTypes.ToListAsync();
        }
        public async Task<PaymentType> GetByIdAsync(int id)
        {
            var paymentType = await _context.PaymentTypes.FindAsync(id);
            return paymentType ?? throw new KeyNotFoundException($"PaymentType with ID {id} was not found.");
        }
        public async Task CreatePaymentTypeAsync(CreatePaymentTypeDTO createPaymentTypeDTO)
        {
            var paymentType = new PaymentType { Name = createPaymentTypeDTO.Name };
            await _context.PaymentTypes.AddAsync(paymentType);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePaymentTypeAsync(UpdatePaymentTypeDTO updatePaymentTypeDTO)
        {
            var paymentType = await _context.PaymentTypes.FindAsync(updatePaymentTypeDTO.Id);
            if (paymentType != null)
            {
                paymentType.Name = updatePaymentTypeDTO.Name;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeletePaymentTypeAsync(int id)
        {
            var paymentType = await _context.PaymentTypes.FindAsync(id);
            if (paymentType != null)
            {
                _context.PaymentTypes.Remove(paymentType);
                await _context.SaveChangesAsync();
            }
        }
    }
}