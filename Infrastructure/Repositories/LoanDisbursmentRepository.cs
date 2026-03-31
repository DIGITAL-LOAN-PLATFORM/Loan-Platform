using Application.DTO;
using Domain.Entities;
using Infrastructure.Data;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Infrastructure.Repositories
{
    //Implements the ILoanDisbursmentRepository interface
    public class LoanDisbursmentRepository : ILoanDisbursment
    {
        //Dependency Injection
        private readonly ApplicationDbContext _context;

        //Constructor
        public LoanDisbursmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //CreateLoanDisbursmentAsync
        public async Task<LoanDisbursment> CreateLoanDisbursment(CreateLoanDisbursmentDTO createLoanDisbursmentDTO)
        {
            var loanDisbursment = new LoanDisbursment
            {
                LoanApplicationId = createLoanDisbursmentDTO.LoanApplicationId,
                PaymentModalityId = createLoanDisbursmentDTO.PaymentModalityId,
                DisbursedAmount = createLoanDisbursmentDTO.DisbursedAmount,
                PaymentMode = createLoanDisbursmentDTO.PaymentMode,
                ReferenceNumber = createLoanDisbursmentDTO.ReferenceNumber,
                InterestRate = createLoanDisbursmentDTO.InterestRate,
                TotalRepaymentAmount = createLoanDisbursmentDTO.TotalRepaymentAmount,
                AccountId = createLoanDisbursmentDTO.AccountId,
                DisbursementDate = createLoanDisbursmentDTO.DisbursementDate,
                InterestClockStartDate = createLoanDisbursmentDTO.InterestClockStartDate,
                InterestClockEndDate = createLoanDisbursmentDTO.InterestClockEndDate,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.LoanDisbursments.Add(loanDisbursment);
            await _context.SaveChangesAsync();

            return loanDisbursment;
        }
        //UpdateLoanDisbursmentAsync
        public async Task<LoanDisbursment> UpdateLoanDisbursment(UpdateLoanDisbursmentDTO updateLoanDisbursmentDTO)
        {
            var loanDisbursment = await _context.LoanDisbursments.FindAsync(updateLoanDisbursmentDTO.Id);
            if (loanDisbursment != null)
            {
                loanDisbursment.LoanApplicationId = updateLoanDisbursmentDTO.LoanApplicationId;
                loanDisbursment.PaymentModalityId = updateLoanDisbursmentDTO.PaymentModalityId;
                loanDisbursment.DisbursedAmount = updateLoanDisbursmentDTO.DisbursedAmount;
                loanDisbursment.PaymentMode = updateLoanDisbursmentDTO.PaymentMode;
                loanDisbursment.ReferenceNumber = updateLoanDisbursmentDTO.ReferenceNumber;
                loanDisbursment.InterestRate = updateLoanDisbursmentDTO.InterestRate;
                loanDisbursment.TotalRepaymentAmount = updateLoanDisbursmentDTO.TotalRepaymentAmount;
                loanDisbursment.AccountId = updateLoanDisbursmentDTO.AccountId;
                loanDisbursment.DisbursementDate = updateLoanDisbursmentDTO.DisbursementDate;
                loanDisbursment.InterestClockStartDate = updateLoanDisbursmentDTO.InterestClockStartDate;
                loanDisbursment.InterestClockEndDate = updateLoanDisbursmentDTO.InterestClockEndDate;
                loanDisbursment.UpdatedAt = DateTime.Now;

                _context.LoanDisbursments.Update(loanDisbursment);
                await _context.SaveChangesAsync();

                return loanDisbursment;
            }
            return null;
        }
        //DeleteLoanDisbursmentAsync
        public async Task<LoanDisbursment> DeleteLoanDisbursment(DeleteLoanDisbursmentDTO deleteLoanDisbursmentDTO)
        {
            var loanDisbursment = await _context.LoanDisbursments.FindAsync(deleteLoanDisbursmentDTO.Id);
            if (loanDisbursment != null)
            {
                _context.LoanDisbursments.Remove(loanDisbursment);
                await _context.SaveChangesAsync();

                return loanDisbursment;
            }
            return null;
        }
        //GetLoanDisbursmentByIdAsync
        public async Task<LoanDisbursment> GetLoanDisbursmentByIdAsync(int id)
        {
            return await _context.LoanDisbursments.FindAsync(id);
        }
        //GetAllLoanDisbursmentAsync
        public async Task<List<LoanDisbursment>> GetAllLoanDisbursmentAsync()
        {
            return await _context.LoanDisbursments.ToListAsync();
        }
    }
}