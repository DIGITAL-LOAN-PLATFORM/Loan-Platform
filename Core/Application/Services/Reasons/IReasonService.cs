using Application.DTO;
using Domain.Entities;

namespace Application.Services.Reasons
{
    public interface IReasonService
    {
        //Get All
        Task<List<Reason>> GetAllAsync();
        //Get By Id
        Task<Reason> GetByIdAsync(int id);
        //Create
        Task CreateReasonAsync(CreateReasonDTO createReasonDTO);
        //Update
        Task UpdateReasonAsync(UpdateReasonDTO updateReasonDTO);
        //Delete
        Task DeleteReasonAsync(int id);
    }
}
