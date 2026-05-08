using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Application.DTO;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories

{
    public class CollateralRepository : ICollateral
    {
        // private readonly ApplicationDbContext dbContext;
        // public BorrowerRepository(ApplicationDbContext context)
        private readonly ApplicationDbContext _context;

        public CollateralRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    
        public async Task<List<Collateral>> GetAllCollateralsAsync()
        {
            return await _context.Collaterals
                .Include(g => g.LoanApplication)
                .ToListAsync();
        }
        public async Task<Collateral> GetCollateralByIdAsync(int id)
        {
            var collateral = await _context.Collaterals
                .FirstOrDefaultAsync(g => g.Id == id);

            return collateral ?? throw new KeyNotFoundException($"Collateral with ID {id} was not found.");
        }

        public async Task CreateCollateralAsync(CollateralCreateDTO collateralDTO)
        {
            var loanApplication = await _context.LoanApplications.FindAsync(collateralDTO.LoanApplicationId);
            // var borrowerType = await dbContext.BorrowerTypes.FindAsync(borrowerDTO.BorrowerTypeId);
            var collateral = new Collateral
            {
                AssetName = collateralDTO.AssetName,
                AssetType = collateralDTO.AssetType,
                LoanApplication = loanApplication,
                Province = collateralDTO.Province,
                District = collateralDTO.District,
                Sector = collateralDTO.Sector,
                Cell = collateralDTO.Cell,
                Village = collateralDTO.Village,
                EstimatedValue = collateralDTO.EstimatedValue,
                IdentificationNumber = collateralDTO.IdentificationNumber,
                Description = collateralDTO.Description,
                ValuerName = collateralDTO.ValuerName,
                ValuationDate = collateralDTO.ValuationDate,
                

            };

            await _context.Collaterals.AddAsync(collateral);

            await _context.SaveChangesAsync();

        }

        public async Task UpdateCollateralAsync(int Id, CollateralUpdateDTO collateralDTO)
        {
            var collateral = await _context.Collaterals.FindAsync(collateralDTO);
            if (collateral == null)


                collateral.AssetName = collateralDTO.AssetName;
                collateral.AssetType = collateralDTO.AssetType;
                collateral.Province = collateralDTO.Province;
                collateral.District = collateralDTO.District;
                collateral.Sector = collateralDTO.Sector;
                collateral.Cell = collateralDTO.Cell;
                collateral.Village = collateralDTO.Village;
                collateral.EstimatedValue = collateralDTO.EstimatedValue;
                collateral.IdentificationNumber = collateralDTO.IdentificationNumber;
                collateral.Description = collateralDTO.Description;
                collateral.ValuerName = collateralDTO.ValuerName;
                collateral.ValuationDate = collateralDTO.ValuationDate;

            await _context.SaveChangesAsync();

        }
    }
}
