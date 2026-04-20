using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories

{

    public class GuarantorRepository : IGuarantor

    {
        private readonly ApplicationDbContext _context;

        public GuarantorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Guarantor>> GetAllAsync()
        {
            return await _context.Guarantors
                .Include(g => g.LoanApplication)
                .Include(g => g.GuarantorType)
                .ToListAsync();
        }
        public async Task<Guarantor> GetByIdAsync(int id)
        {
            var guarantor = await _context.Guarantors
                .Include(g => g.LoanApplication)
                .Include(g => g.GuarantorType)
                .FirstOrDefaultAsync(g => g.Id == id);

            return guarantor ?? throw new KeyNotFoundException($"Guarantor with ID {id} was not found.");
        }
        public async Task CreateGuarantorAsync(CreateGuarantorDTO createGuarantorDTO)
        {
            var guarantor = new Guarantor
            {
                IdentificationNumber = createGuarantorDTO.IdentificationNumber,

                Name = createGuarantorDTO.Name,

                DOB = createGuarantorDTO.DOB ,

                Email = createGuarantorDTO.Email,

                Phone = createGuarantorDTO.Phone,
                
                GuarantorType = createGuarantorDTO.GuarantorType,

                Province = createGuarantorDTO.Province,

                District = createGuarantorDTO.District,

                Sector = createGuarantorDTO.Sector,

                Cell = createGuarantorDTO.Cell,

                Village = createGuarantorDTO.Village,

                LoanApplicationId = createGuarantorDTO.LoanApplicationId

            };

            await _context.Guarantors.AddAsync(guarantor);

            await _context.SaveChangesAsync();

        }
        public async Task UpdateGuarantorAsync(UpdateGuarantorDTO updateGuarantorDTO)
        {
            var guarantor = await _context.Guarantors.FindAsync(updateGuarantorDTO.Id);
            if (guarantor == null)

                return;

                guarantor.IdentificationNumber = updateGuarantorDTO.IdentificationNumber;

                guarantor.Name = updateGuarantorDTO.Name;

                guarantor.DOB = updateGuarantorDTO.DOB;

                guarantor.Email = updateGuarantorDTO.Email;

                guarantor.Phone = updateGuarantorDTO.Phone;

                guarantor.Province = updateGuarantorDTO.Province;

                guarantor.District = updateGuarantorDTO.District;

                guarantor.Sector = updateGuarantorDTO.Sector;

                guarantor.Cell = updateGuarantorDTO.Cell;

                guarantor.Village = updateGuarantorDTO.Village;

                guarantor.LoanApplicationId = updateGuarantorDTO.LoanApplicationId;

            await _context.SaveChangesAsync();

        }
        public async Task DeleteGuarantorAsync(int id)
        {
            var guarantor = await _context.Guarantors.FindAsync(id);
            if (guarantor != null)
            {
                _context.Guarantors.Remove(guarantor);

                await _context.SaveChangesAsync();
            }

        }

    }

}

