using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IGuarantorType
    {
        //Get All
        Task<List<GuarantorType>> GetAllAsync();
        //Get By Id
        Task<GuarantorType> GetByIdAsync(int id);
        //Create
        Task CreateGuarantorTypeAsync(CreateGuarantorTypeDTO createGuarantorTypeDTO);
        //Update
        Task UpdateGuarantorTypeAsync(UpdateGuarantorTypeDTO updateGuarantorTypeDTO);
        //Delete
        Task DeleteGuarantorTypeAsync(int id);
    }
}
