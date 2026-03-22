using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IBorrower
    {
        Task<List<Borrower>> GetAllAsync();
        Task<Borrower> GetByIdAsync(int id);
        Task CreateBorrowerAsync(CreateBorrowerDTO createBorrowerDTO);
        Task UpdateBorrowerAsync(UpdateBorrowerDTO updateBorrowerDTO);
        Task DeleteBorrowerAsync(int id);
    }
}