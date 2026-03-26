using Application.DTO;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services.Reasons
{
    public class ReasonService : IReasonService
    {
        //
        private readonly IReason _reason;
        
        //Constructor
        public ReasonService(IReason reason)
        {
            _reason = reason;
        }

        //Get All
        public async Task<List<Reason>> GetAllAsync()
        {
            return await _reason.GetAllAsync();
        }

        //Get By Id
        public async Task<Reason> GetByIdAsync(int id)
        {
            return await _reason.GetByIdAsync(id);
        }

        //Create
        public async Task CreateReasonAsync(CreateReasonDTO createReasonDTO)
        {
            await _reason.CreateReasonAsync(createReasonDTO);
        }

        //Update
        public async Task UpdateReasonAsync(UpdateReasonDTO updateReasonDTO)
        {
            await _reason.UpdateReasonAsync(updateReasonDTO);
        }

        //Delete
        public async Task DeleteReasonAsync(int id)
        {
            await _reason.DeleteReasonAsync(id);
        }
    }
}
