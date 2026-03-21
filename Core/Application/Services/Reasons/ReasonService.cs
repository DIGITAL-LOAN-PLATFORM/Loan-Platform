using Application.DTO;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services.Reasons
{
    public class ReasonService : IReasonService
    {
        private readonly IReason _reason;

        public ReasonService(IReason reason)
        {
            _reason = reason;
        }

        public async Task<List<Reason>> GetAllAsync()
        {
            return await _reason.GetAllAsync();
        }

        public async Task<Reason> GetByIdAsync(int id)
        {
            return await _reason.GetByIdAsync(id);
        }

        public async Task CreateReasonAsync(CreateReasonDTO createReasonDTO)
        {
            await _reason.CreateReasonAsync(createReasonDTO);
        }

        public async Task UpdateReasonAsync(UpdateReasonDTO updateReasonDTO)
        {
            await _reason.UpdateReasonAsync(updateReasonDTO);
        }

        public async Task DeleteReasonAsync(int id)
        {
            await _reason.DeleteReasonAsync(id);
        }
    }
}
