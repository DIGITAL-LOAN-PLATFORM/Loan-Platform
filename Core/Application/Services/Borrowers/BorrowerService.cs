using Application.Interfaces;

using Domain.Entities;

using Application.DTO;





namespace Application.Services.Borrowers

{
    public class BorrowerService : IBorrowerService
    {
         private readonly IBorrower _borrower;
        public BorrowerService(IBorrower borrower)

        {
         _borrower = borrower;
        }
        public async Task<List<Borrower>> GetAllAsync()
        {
            return await _borrower.GetAllAsync();
        }
        public async Task<Borrower> GetByIdAsync(int id)
        {
            return await _borrower.GetByIdAsync(id);
        }
        public async Task CreateBorrowerAsync(CreateBorrowerDTO createBorrowerDTO)
        {
            await _borrower.CreateBorrowerAsync(createBorrowerDTO);
        }
        public async Task UpdateBorrowerAsync(UpdateBorrowerDTO updateBorrowerDTO)
        {
            await _borrower.UpdateBorrowerAsync(updateBorrowerDTO);
        }
        public async Task DeleteBorrowerAsync(int id)
        {
            await _borrower.DeleteBorrowerAsync(id);
        }

    }

}

