using Application.DTO;
using Domain.Entities;
using Application.Interfaces;

namespace Application.Services.Accounts
{
    public class AccountService : IAccountService
    {
        //Dependency Injection
        private readonly IAccount _account;

        //Constructor
        public AccountService(IAccount account)
        {
            _account = account;
        }

        //Get All
        public async Task<List<Account>> GetAllAsync()
        {
            return await _account.GetAllAsync();
        }

        //Get By Id
        public async Task<Account> GetByIdAsync(int id)
        {
            return await _account.GetByIdAsync(id);
        }

        //Create
        public async Task CreateAccountAsync(CreateAccountDTO createAccountDTO)
        {
            await _account.CreateAccountAsync(createAccountDTO);
        }

        //Update
        public async Task UpdateAccountAsync(UpdateAccountDTO updateAccountDTO)
        {
            await _account.UpdateAccountAsync(updateAccountDTO);
        }

        public async Task DeleteAccountAsync(int id)
        {
            await _account.DeleteAccountAsync(id);
        }
    }
}