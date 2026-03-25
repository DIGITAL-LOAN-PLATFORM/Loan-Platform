using Application.DTO;
using Domain.Entities;
namespace Application.Interfaces
{
    public interface IPaymentType
    {
        //Get All
        Task<List<PaymentType>> GetAllAsync();
        //Get By Id
        Task<PaymentType> GetByIdAsync(int id);
        //Create
        Task CreatePaymentTypeAsync(CreatePaymentTypeDTO createPaymentTypeDTO);
        //Update
        Task UpdatePaymentTypeAsync(UpdatePaymentTypeDTO updatePaymentTypeDTO);
        //Delete
        Task DeletePaymentTypeAsync(int id);
    }
}