using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class LoanInstallmentRepository : ILoanInstallment
    {
        private readonly ApplicationDbContext _context;

        public LoanInstallmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LoanInstallment> CreateLoanInstallment(LoanInstallmentDTO dto)
        {
            var loanInstallment = new LoanInstallment
            {
                LoanDisbursmentId = dto.LoanDisbursmentId,
                DueDate = dto.DueDate,
                AmountDue = dto.AmountDue,
                PenaltyAmount = dto.PenaltyAmount,
                AmountPaid = dto.AmountPaid,
                Status = dto.Status
            };

            await _context.LoanInstallments.AddAsync(loanInstallment);
            await _context.SaveChangesAsync();
            return loanInstallment;
        }

        public async Task<List<LoanInstallment>> GetAllLoanInstallmentAsync()
        {
            return await _context.LoanInstallments
                .Include(i => i.LoanDisbursment)
                    .ThenInclude(d => d.LoanApplication)
                        .ThenInclude(a => a.Borrower)
                .ToListAsync();
        }

        public async Task<LoanInstallment> GetLoanInstallmentByIdAsync(int id)
        {
            return await _context.LoanInstallments
                .Include(i => i.LoanDisbursment)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<LoanInstallment> UpdateLoanInstallment(LoanInstallmentDTO dto)
        {
            var installment = await _context.LoanInstallments.FirstOrDefaultAsync(i => i.Id == dto.Id);
            if (installment != null)
            {
                installment.AmountPaid = dto.AmountPaid;
                installment.PenaltyAmount = dto.PenaltyAmount;
                installment.Status = dto.Status;
                installment.UpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return installment;
        }

        public async Task<List<LoanInstallment>> GetLoanInstallmentsByDisbursementIdAsync(int disbursementId)
        {
            return await _context.LoanInstallments
                .Where(i => i.LoanDisbursmentId == disbursementId)
                .OrderBy(i => i.DueDate)
                .ToListAsync();
        }
    }
}
