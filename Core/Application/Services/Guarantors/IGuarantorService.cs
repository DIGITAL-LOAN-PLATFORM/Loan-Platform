using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IGuarantorService
    {
        Task<List<Guarantor>> GetAllAsync();
        Task<Guarantor> GetByIdAsync(int id);
        Task CreateGuarantorAsync(CreateGuarantorDTO createGuarantorDTO);
        Task UpdateGuarantorAsync(UpdateGuarantorDTO updateGuarantorDTO);
        Task DeleteGuarantorAsync(int id);
    }
}
