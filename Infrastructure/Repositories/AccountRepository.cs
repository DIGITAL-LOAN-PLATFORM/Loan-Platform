using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.DTO;
using Domain.ValueObjects;

namespace Infrastructure.Repositories
{
    //Implementation of IAccount interface
    public class AccountRepository : IAccount
    {
        //Dependency Injection
        private readonly ApplicationDbContext _context;

        //Constructor
        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get All
        public async Task<List<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        //Get By Id
        public async Task<Account> GetByIdAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);

            return account ?? throw new KeyNotFoundException($"Account with ID {id} was not found.");
        }

        //Create
        public async Task CreateAccountAsync(CreateAccountDTO createAccountDTO)
        {
            var account = new Account
            {
                Name = createAccountDTO.Name,

                Provider = createAccountDTO.Provider,

                Number = createAccountDTO.Number,

                Type = (AccountType)createAccountDTO.Type,

                Balance = createAccountDTO.Balance
            };

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        //Update
        public async Task UpdateAccountAsync(UpdateAccountDTO updateAccountDTO)
        {
            var account = await _context.Accounts.FindAsync(updateAccountDTO.Id);

            if (account == null)
            {
                throw new KeyNotFoundException($"Account with ID {updateAccountDTO.Id} was not found.");
            }

            account.Name = updateAccountDTO.Name;
            account.Provider = updateAccountDTO.Provider;
            account.Number = updateAccountDTO.Number;
            account.Type = (AccountType)updateAccountDTO.Type;
            account.Balance = updateAccountDTO.Balance;

            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        //Delete
        public async Task DeleteAccountAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new KeyNotFoundException($"Account with ID {id} was not found.");
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }
    }
}