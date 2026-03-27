using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface ILoanProduct
    {
        //Get All
        Task<List<LoanProduct>> GetAllAsync();
        //Get By Id
        Task<LoanProduct> GetByIdAsync(int id);
        //Create
        Task CreateLoanProductAsync(CreateLoanProductDTO createLoanProductDTO);
        //Update
        Task UpdateLoanProductAsync(UpdateLoanProductDTO updateLoanProductDTO);
        //Delete
        Task DeleteLoanProductAsync(int id);
    }
}