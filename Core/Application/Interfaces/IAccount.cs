using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IAccount
    {
        //Get All
        Task<List<Account>> GetAllAsync();
        //Get By Id
        Task<Account> GetByIdAsync(int id);
        //Create
        Task CreateAccountAsync(CreateAccountDTO createAccountDTO);
        //Update
        Task UpdateAccountAsync(UpdateAccountDTO updateAccountDTO);
        //Delete
        Task DeleteAccountAsync(int id);
    }
}