using Domain.Entities;
using Application.DTO;
using Application.Interfaces;

namespace Application.Services.LoanProducts
{
    public interface ILoanProductService
    {
        Task<List<LoanProduct>> GetAllAsync();
        Task<LoanProduct> GetByIdAsync(int id);
        Task CreateLoanProductAsync(CreateLoanProductDTO createLoanProductDTO);
        Task UpdateLoanProductAsync(UpdateLoanProductDTO updateLoanProductDTO);
        Task DeleteLoanProductAsync(int id);
    }
}