using Application.Interfaces;
using Domain.Entities;
using Application.DTO; 

namespace Application.Services.LoanProductSettings
{
    public class LoanProductSettingService : ILoanProductSettingService
    {
        private readonly ILoanProductSetting _loanProductSetting;
        public LoanProductSettingService(ILoanProductSetting loanProductSetting)
        {
            _loanProductSetting = loanProductSetting;
        }
        public async Task<List<LoanProductSetting>> GetAllAsync()
        {
            return await _loanProductSetting.GetAllAsync();
        }
        public async Task<LoanProductSetting> GetByIdAsync(int id)
        {
            return await _loanProductSetting.GetByIdAsync(id);
        }
        public async Task CreateLoanProductSettingAsync(CreateLoanProductSettingDTO createLoanProductSettingDTO)
        {
            await _loanProductSetting.CreateLoanProductSettingAsync(createLoanProductSettingDTO);
        }
        public async Task UpdateLoanProductSettingAsync(UpdateLoanProductSettingDTO updateLoanProductSettingDTO)
        {
            await _loanProductSetting.UpdateLoanProductSettingAsync(updateLoanProductSettingDTO);
        }
        public async Task DeleteLoanProductSettingAsync(int id)
        {
            await _loanProductSetting.DeleteLoanProductSettingAsync(id);
        }

    }

}