using Application.DTO;
using Domain.Entities;
using Application.Interfaces;

namespace Application.Services.LoanDisbursments
{
    public interface ILoanDisbursmentService
    {
        //Create a new loan disbursment
        Task CreateLoanDisbursment(CreateLoanDisbursmentDTO createLoanDisbursmentDTO);
        //Update an existing loan disbursment
        Task UpdateLoanDisbursment(UpdateLoanDisbursmentDTO updateLoanDisbursmentDTO);
        //Get a loan disbursment by id
        Task<LoanDisbursment> GetLoanDisbursment(int id);
        //Get all loan disbursments
        Task<List<LoanDisbursment>> GetAllLoanDisbursments();
        //Delete a loan disbursment by id
        Task DeleteLoanDisbursment(int id);
    }
}