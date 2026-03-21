using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ReasonRepository : IReason
    {
        private readonly ApplicationDbContext _context;

        public ReasonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reason>> GetAllAsync()
        {
            return await _context.Reasons.ToListAsync();
        }

        public async Task<Reason> GetByIdAsync(int id)
        {
            var reason = await _context.Reasons.FindAsync(id);
            return reason ?? throw new KeyNotFoundException($"Reason with ID {id} was not found.");
        }

        public async Task CreateReasonAsync(CreateReasonDTO createReasonDTO)
        {
            var reason = new Reason { Name = createReasonDTO.Name };
            await _context.Reasons.AddAsync(reason);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReasonAsync(UpdateReasonDTO updateReasonDTO)
        {
            var reason = await _context.Reasons.FindAsync(updateReasonDTO.Id);
            if (reason != null)
            {
                reason.Name = updateReasonDTO.Name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteReasonAsync(int id)
        {
            var reason = await _context.Reasons.FindAsync(id);
            if (reason != null)
            {
                _context.Reasons.Remove(reason);
                await _context.SaveChangesAsync();
            }
        }
    }
}
