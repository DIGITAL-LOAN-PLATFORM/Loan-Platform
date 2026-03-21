using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IReason
    {
        Task<List<Reason>> GetAllAsync();
        Task<Reason> GetByIdAsync(int id);
        Task CreateReasonAsync(CreateReasonDTO createReasonDTO);
        Task UpdateReasonAsync(UpdateReasonDTO updateReasonDTO);
        Task DeleteReasonAsync(int id);
    }
}
