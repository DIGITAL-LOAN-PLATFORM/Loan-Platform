using Domain.Entities;
using Application.DTO;
using Application.Interfaces;

namespace Application.Services.Borrowers
{
    public interface IBorrowerService
    {
        Task<List<Borrower>> GetAllAsync();
        Task<Borrower> GetByIdAsync(int id);
        Task CreateBorrowerAsync(CreateBorrowerDTO createBorrowerDTO);
        Task UpdateBorrowerAsync(UpdateBorrowerDTO updateBorrowerDTO);
        Task DeleteBorrowerAsync(int id);
    }
}