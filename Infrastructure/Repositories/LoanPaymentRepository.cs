using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class LoanPaymentRepository : ILoanPayment
    {
        private readonly ApplicationDbContext _context;

        public LoanPaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LoanPayment> CreateLoanPayment(CreateLoanPaymentDTO dto)
        {
            var payment = new LoanPayment
            {
                LoanInstallmentId = dto.LoanInstallmentId,
                AccountId = dto.AccountId,
                PaymentDate = dto.PaymentDate,
                Amount = dto.Amount,
                PaymentMode = dto.PaymentMode,
                ReferenceNumber = dto.ReferenceNumber
            };

            await _context.LoanPayments.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<List<LoanPayment>> GetAllLoanPaymentAsync()
        {
            return await _context.LoanPayments
                .Include(p => p.LoanInstallment)
                .ToListAsync();
        }

        public async Task<LoanPayment> GetLoanPaymentByIdAsync(int id)
        {
            return await _context.LoanPayments.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
