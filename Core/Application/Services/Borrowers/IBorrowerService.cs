using Domain.Entities;
using Application.DTO;
using Application.Interfaces;

namespace Application.Services.Borrowers
{
    public interface IBorrowerService
    {
        //Get all borrowers
        Task<List<Borrower>> GetAllAsync();
        //Get a borrower by id
        Task<Borrower> GetByIdAsync(int id);
        //Create a new borrower
        Task CreateBorrowerAsync(CreateBorrowerDTO createBorrowerDTO);
        //Update an existing borrower
        Task UpdateBorrowerAsync(UpdateBorrowerDTO updateBorrowerDTO);
        //Delete a borrower by id
        Task DeleteBorrowerAsync(int id);
    }
}