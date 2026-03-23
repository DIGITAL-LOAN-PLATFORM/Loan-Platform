using Application.Interfaces;
using Domain.Entities;
using Application.DTO; 

namespace Application.Services.LoanProducts
{
    public class LoanProductService : ILoanProductService
    {
        private readonly ILoanProduct _loanProduct;
        public LoanProductService(ILoanProduct loanProduct)
        {
            _loanProduct = loanProduct;
        }
        public async Task<List<LoanProduct>> GetAllAsync()
        {
            return await _loanProduct.GetAllAsync();
        }
        public async Task<LoanProduct> GetByIdAsync(int id)
        {
            return await _loanProduct.GetByIdAsync(id);
        }
        public async Task CreateLoanProductAsync(CreateLoanProductDTO createLoanProductDTO)
        {
            await _loanProduct.CreateLoanProductAsync(createLoanProductDTO);
        }
        public async Task UpdateLoanProductAsync(UpdateLoanProductDTO updateLoanProductDTO)
        {
            await _loanProduct.UpdateLoanProductAsync(updateLoanProductDTO);
        }
        public async Task DeleteLoanProductAsync(int id)
        {
            await _loanProduct.DeleteLoanProductAsync(id);
        }

    }

}