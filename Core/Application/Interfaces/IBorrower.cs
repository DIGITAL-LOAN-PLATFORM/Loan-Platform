using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IBorrower
    {
        //Get All
        Task<List<Borrower>> GetAllAsync();
        //Get By Id
        Task<Borrower> GetByIdAsync(int id);
        //Create
        Task CreateBorrowerAsync(CreateBorrowerDTO createBorrowerDTO);
        //Update
        Task UpdateBorrowerAsync(UpdateBorrowerDTO updateBorrowerDTO);
        //Delete
        Task DeleteBorrowerAsync(int id);
    }
}