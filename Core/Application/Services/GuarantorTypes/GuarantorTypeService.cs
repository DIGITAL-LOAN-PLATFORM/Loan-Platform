using Application.DTO;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services.GuarantorTypes
{
    public class GuarantorTypeService : IGuarantorTypeService
    {
        private readonly IGuarantorType _guarantorType;

        public GuarantorTypeService(IGuarantorType guarantorType)
        {
            _guarantorType = guarantorType;
        }

        public async Task<List<GuarantorType>> GetAllAsync()
        {
            return await _guarantorType.GetAllAsync();
        }

        public async Task<GuarantorType> GetByIdAsync(int id)
        {
            return await _guarantorType.GetByIdAsync(id);
        }

        public async Task CreateGuarantorTypeAsync(CreateGuarantorTypeDTO createGuarantorTypeDTO)
        {
            await _guarantorType.CreateGuarantorTypeAsync(createGuarantorTypeDTO);
        }

        public async Task UpdateGuarantorTypeAsync(UpdateGuarantorTypeDTO updateGuarantorTypeDTO)
        {
            await _guarantorType.UpdateGuarantorTypeAsync(updateGuarantorTypeDTO);
        }

        public async Task DeleteGuarantorTypeAsync(int id)
        {
            await _guarantorType.DeleteGuarantorTypeAsync(id);
        }
    }
}
