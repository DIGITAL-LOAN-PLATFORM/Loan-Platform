using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class LoanProductRepository : ILoanProduct
    {
        private readonly ApplicationDbContext _context;

        public LoanProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LoanProduct>> GetAllAsync()
        {
            return await _context.LoanProducts.ToListAsync();
        }

        public async Task<LoanProduct> GetByIdAsync(int id)
        {
            var loanProduct = await _context.LoanProducts.FindAsync(id);

            return loanProduct ?? throw new KeyNotFoundException($"Loan product with ID {id} was not found.");
        }

        public async Task CreateLoanProductAsync(CreateLoanProductDTO createLoanProductDTO)
        {
            var loanProduct = new LoanProduct
            {
                Name = createLoanProductDTO.Name,
                Description = createLoanProductDTO.Description,
                InterestRate = createLoanProductDTO.InterestRate,
                CreatedAt = DateTime.UtcNow
            };

            _context.LoanProducts.Add(loanProduct);
            await _context.LoanProducts.AddAsync(loanProduct);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateLoanProductAsync(UpdateLoanProductDTO updateLoanProductDTO)
        {
            var loanProduct = await _context.LoanProducts.FindAsync(updateLoanProductDTO.Id);

            if (loanProduct != null)
            {
                loanProduct.Name = updateLoanProductDTO.Name;
                loanProduct.Description = updateLoanProductDTO.Description;
                loanProduct.InterestRate = updateLoanProductDTO.InterestRate;

                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteLoanProductAsync(int id)
        {
            var loanProduct = await _context.LoanProducts.FindAsync(id);

            if (loanProduct != null)
            {
                _context.LoanProducts.Remove(loanProduct);
                await _context.SaveChangesAsync();
            }
        } 
    }
}
