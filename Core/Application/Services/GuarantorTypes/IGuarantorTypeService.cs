using Application.DTO;
using Domain.Entities;

namespace Application.Services.GuarantorTypes
{
    public interface IGuarantorTypeService
    {
        Task<List<GuarantorType>> GetAllAsync();
        Task<GuarantorType> GetByIdAsync(int id);
        Task CreateGuarantorTypeAsync(CreateGuarantorTypeDTO createGuarantorTypeDTO);
        Task UpdateGuarantorTypeAsync(UpdateGuarantorTypeDTO updateGuarantorTypeDTO);
        Task DeleteGuarantorTypeAsync(int id);
    }
}
