using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface ILoanProductSetting
    {
        //Get All
        Task<List<LoanProductSetting>> GetAllAsync();
        //Get By Id
        Task<LoanProductSetting> GetByIdAsync(int id);
        //Create
        Task CreateLoanProductSettingAsync(CreateLoanProductSettingDTO createLoanProductSettingDTO);
        //Update
        Task UpdateLoanProductSettingAsync(UpdateLoanProductSettingDTO updateLoanProductSettingDTO);
        //Delete
        Task DeleteLoanProductSettingAsync(int id);
    }
}