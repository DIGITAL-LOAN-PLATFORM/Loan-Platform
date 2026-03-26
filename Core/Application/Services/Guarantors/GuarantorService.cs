using Application.Interfaces;
using Domain.Entities;
using Application.DTO;

namespace Application.Services.Guarantors

{
    public class GuarantorService : IGuarantorService
    {
         private readonly IGuarantor _guarantor;
        public GuarantorService(IGuarantor guarantor)

        {
         _guarantor = guarantor;
        }
        public async Task<List<Guarantor>> GetAllAsync()
        {
            return await _guarantor.GetAllAsync();
        }
        public async Task<Guarantor> GetByIdAsync(int id)
        {
            return await _guarantor.GetByIdAsync(id);
        }
        public async Task CreateGuarantorAsync(CreateGuarantorDTO createGuarantorDTO)
        {
            await _guarantor.CreateGuarantorAsync(createGuarantorDTO);
        }
        public async Task UpdateGuarantorAsync(UpdateGuarantorDTO updateGuarantorDTO)
        {
            await _guarantor.UpdateGuarantorAsync(updateGuarantorDTO);
        }
        public async Task DeleteGuarantorAsync(int id)
        {
            await _guarantor.DeleteGuarantorAsync(id);
        }

    }

}

