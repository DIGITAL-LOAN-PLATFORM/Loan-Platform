using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories

{

    public class BorrowerRepository : IBorrower

    {
        private readonly ApplicationDbContext _context;

        public BorrowerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Borrower>> GetAllAsync()
        {
            return await _context.Borrowers.ToListAsync();
        }
        public async Task<Borrower> GetByIdAsync(int id)
        {
            var borrower = await _context.Borrowers.FindAsync(id);

            return borrower ?? throw new KeyNotFoundException($"Borrower with ID {id} was not found.");
        }
        public async Task CreateBorrowerAsync(CreateBorrowerDTO createBorrowerDTO)
        {
            var borrower = new Borrower
            {
                IdentificationNumber = createBorrowerDTO.IdentificationNumber,

                FirstName = createBorrowerDTO.FirstName,

                LastName = createBorrowerDTO.LastName,

                Gender = createBorrowerDTO.Gender,

                Email = createBorrowerDTO.Email,

                PhoneNumber = createBorrowerDTO.PhoneNumber,

                DOB = createBorrowerDTO.DOB,

                MaritalStatus = createBorrowerDTO.MaritalStatus,

                SpouseName = createBorrowerDTO.SpouseName,

                SpouseId = createBorrowerDTO.SpouseId,

                Province = createBorrowerDTO.Province,

                District = createBorrowerDTO.District,

                Sector = createBorrowerDTO.Sector,

                Cell = createBorrowerDTO.Cell,

                Village = createBorrowerDTO.Village,

                CreatedAt = DateTime.UtcNow

            };

            await _context.Borrowers.AddAsync(borrower);

            await _context.SaveChangesAsync();

        }
        public async Task UpdateBorrowerAsync(UpdateBorrowerDTO updateBorrowerDTO)
        {
            var borrower = await _context.Borrowers.FindAsync(updateBorrowerDTO.Id);
            if (borrower == null)

                return;

            borrower.IdentificationNumber = updateBorrowerDTO.IdentificationNumber;

            borrower.FirstName = updateBorrowerDTO.FirstName;

            borrower.LastName = updateBorrowerDTO.LastName;

            borrower.Gender = updateBorrowerDTO.Gender;

            borrower.Email = updateBorrowerDTO.Email;

            borrower.PhoneNumber = updateBorrowerDTO.PhoneNumber;

            borrower.DOB = updateBorrowerDTO.DOB;

            borrower.MaritalStatus = updateBorrowerDTO.MaritalStatus;

            borrower.SpouseName = updateBorrowerDTO.SpouseName;

            borrower.SpouseId = updateBorrowerDTO.SpouseId;

            borrower.Province = updateBorrowerDTO.Province;

            borrower.District = updateBorrowerDTO.District;

            borrower.Sector = updateBorrowerDTO.Sector;

            borrower.Cell = updateBorrowerDTO.Cell;

            borrower.Village = updateBorrowerDTO.Village;

            await _context.SaveChangesAsync();

        }
        public async Task DeleteBorrowerAsync(int id)
        {
            var borrower = await _context.Borrowers.FindAsync(id);
            if (borrower != null)

            {

                _context.Borrowers.Remove(borrower);

                await _context.SaveChangesAsync();

            }

        }

    }

}

