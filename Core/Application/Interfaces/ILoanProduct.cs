using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface ILoanProduct
    {
        Task<List<LoanProduct>> GetAllAsync();
        Task<LoanProduct> GetByIdAsync(int id);
        Task CreateLoanProductAsync(CreateLoanProductDTO createLoanProductDTO);
        Task UpdateLoanProductAsync(UpdateLoanProductDTO updateLoanProductDTO);
        Task DeleteLoanProductAsync(int id);
    }
}