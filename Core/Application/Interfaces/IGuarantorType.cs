using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IGuarantorType
    {
        Task<List<GuarantorType>> GetAllAsync();
        Task<GuarantorType> GetByIdAsync(int id);
        Task CreateGuarantorTypeAsync(CreateGuarantorTypeDTO createGuarantorTypeDTO);
        Task UpdateGuarantorTypeAsync(UpdateGuarantorTypeDTO updateGuarantorTypeDTO);
        Task DeleteGuarantorTypeAsync(int id);
    }
}
