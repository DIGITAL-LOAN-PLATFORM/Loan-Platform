using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class LoanProductSettingRepository : ILoanProductSetting
    {
        private readonly ApplicationDbContext _context;


        public LoanProductSettingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // public async Task<List<LoanProductSetting>> GetAllAsync()
        // {
        //     return await _context.LoanProductSettings.ToListAsync();
        // }
        public async Task<List<LoanProductSetting>> GetAllAsync()
        {
            return await _context.LoanProductSettings
                .Include(g => g.LoanProduct)
                .ToListAsync();
        }

        // public async Task<LoanProductSetting> GetByIdAsync(int id)
        // {
        //     var loanProductSetting = await _context.LoanProductSettings.FindAsync(id);

        //     return loanProductSetting ?? throw new KeyNotFoundException($"Loan product setting with ID {id} was not found.");
        // }
        public async Task<LoanProductSetting> GetByIdAsync(int id)
        {
            var loanProductSetting = await _context.LoanProductSettings
                .Include(g => g.LoanProduct)
                .FirstOrDefaultAsync(g => g.Id == id);

            return loanProductSetting ?? throw new KeyNotFoundException($"Loan product setting with ID {id} was not found.");
        }

        // public async Task CreateLoanProductSettingAsync(CreateLoanProductSettingDTO createLoanProductSettingDTO)
        // {
        //     var loanProductSetting = new LoanProductSetting
        //     {
        //         Name = createLoanProductSettingDTO.Name,
        //         Description = createLoanProductSettingDTO.Description,
        //         Status = createLoanProductSettingDTO.Status,
        //         CreatedAt = DateTime.UtcNow
        //     };

        //     await _context.LoanProductSettings.AddAsync(loanProductSetting);
        //     await _context.SaveChangesAsync();
        // }
        public async Task CreateLoanProductSettingAsync(CreateLoanProductSettingDTO createLoanProductSettingDTO)
        {
            var loanProductSetting = new LoanProductSetting
            {
                LoanProduct = createLoanProductSettingDTO.LoanProduct,

                InterestRate = createLoanProductSettingDTO.InterestRate,

                MaintenanceFee = createLoanProductSettingDTO.MaintenanceFee ,

                ProcessingFee = createLoanProductSettingDTO.ProcessingFee,

                InsuranceFee = createLoanProductSettingDTO.InsuranceFee,
                
                Status = createLoanProductSettingDTO.Status,

                CreatedAt = DateTime.UtcNow

                // LoanApplicationId = createLoanProductSettingDTO.LoanApplicationId

            };

            await _context.LoanProductSettings.AddAsync(loanProductSetting);

            await _context.SaveChangesAsync();

        }
        // public async Task UpdateLoanProductAsync(UpdateLoanProductDTO updateLoanProductDTO)
        // {
        //     var loanProduct = await _context.LoanProducts.FindAsync(updateLoanProductDTO.Id);

        //     if (loanProduct != null)
        //     {
        //         loanProduct.Name = updateLoanProductDTO.Name;
        //         loanProduct.Description = updateLoanProductDTO.Description;
        //         loanProduct.Status = updateLoanProductDTO.Status;

        //         await _context.SaveChangesAsync();
        //     }
        // }
        public async Task UpdateLoanProductSettingAsync(UpdateLoanProductSettingDTO updateLoanProductSettingDTO)
        {
            var loanProductSetting = await _context.LoanProductSettings.FindAsync(updateLoanProductSettingDTO.Id);
            if (loanProductSetting == null)

                return;

                loanProductSetting.InterestRate = updateLoanProductSettingDTO.InterestRate;

                loanProductSetting.MaintenanceFee = updateLoanProductSettingDTO.MaintenanceFee;

                loanProductSetting.ProcessingFee = updateLoanProductSettingDTO.ProcessingFee;

                loanProductSetting.InsuranceFee = updateLoanProductSettingDTO.InsuranceFee;

                loanProductSetting.Status = updateLoanProductSettingDTO.Status;

                loanProductSetting.UpdatedAt = DateTime.UtcNow;

                // loanProductSetting.LoanApplicationId = updateLoanProductSettingDTO.LoanApplicationId;

            await _context.SaveChangesAsync();

        }
        public async Task DeleteLoanProductSettingAsync(int id)
        {
            var loanProductSetting = await _context.LoanProductSettings.FindAsync(id);

            if (loanProductSetting != null)
            {
                _context.LoanProductSettings.Remove(loanProductSetting);
                await _context.SaveChangesAsync();
            }
        } 
    }
}
