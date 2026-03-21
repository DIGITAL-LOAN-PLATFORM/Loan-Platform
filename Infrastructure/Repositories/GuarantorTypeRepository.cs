using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GuarantorTypeRepository : IGuarantorType
    {
        private readonly ApplicationDbContext _context;

        public GuarantorTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GuarantorType>> GetAllAsync()
        {
            return await _context.GuarantorTypes.ToListAsync();
        }

        public async Task<GuarantorType> GetByIdAsync(int id)
        {
            var guarantorType = await _context.GuarantorTypes.FindAsync(id);
            return guarantorType ?? throw new KeyNotFoundException($"GuarantorType with ID {id} was not found.");
        }

        public async Task CreateGuarantorTypeAsync(CreateGuarantorTypeDTO createGuarantorTypeDTO)
        {
            var guarantorType = new GuarantorType { Name = createGuarantorTypeDTO.Name };
            await _context.GuarantorTypes.AddAsync(guarantorType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGuarantorTypeAsync(UpdateGuarantorTypeDTO updateGuarantorTypeDTO)
        {
            var guarantorType = await _context.GuarantorTypes.FindAsync(updateGuarantorTypeDTO.Id);
            if (guarantorType != null)
            {
                guarantorType.Name = updateGuarantorTypeDTO.Name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteGuarantorTypeAsync(int id)
        {
            var guarantorType = await _context.GuarantorTypes.FindAsync(id);
            if (guarantorType != null)
            {
                _context.GuarantorTypes.Remove(guarantorType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
