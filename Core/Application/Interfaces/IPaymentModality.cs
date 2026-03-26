using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPaymentModality
    {
        //Get All
        Task<List<PaymentModality>> GetAllAsync();
        //Get By Id
        Task<PaymentModality> GetByIdAsync(int id);
        //Create
        Task CreatePaymentModalityAsync(CreatePaymentModalityDTO createPaymentModalityDTO);
        //Update
        Task UpdatePaymentModalityAsync(UpdatePaymentModalityDTO updatePaymentModalityDTO);
        //Delete
        Task DeletePaymentModalityAsync(int id);
    }
}
