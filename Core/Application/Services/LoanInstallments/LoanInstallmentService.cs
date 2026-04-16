using Application.DTO;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services.LoanInstallments
{
    public class LoanInstallmentService : ILoanInstallmentService
    {
        private readonly ILoanInstallment _loanInstallmentRepository;

        public LoanInstallmentService(ILoanInstallment loanInstallmentRepository)
        {
            _loanInstallmentRepository = loanInstallmentRepository;
        }

        public async Task<LoanInstallment> CreateLoanInstallmentAsync(LoanInstallmentDTO dto)
        {
            return await _loanInstallmentRepository.CreateLoanInstallment(dto);
        }

        public async Task<List<LoanInstallment>> GetAllLoanInstallmentAsync()
        {
            return await _loanInstallmentRepository.GetAllLoanInstallmentAsync();
        }

        public async Task<LoanInstallment> GetLoanInstallmentByIdAsync(int id)
        {
            return await _loanInstallmentRepository.GetLoanInstallmentByIdAsync(id);
        }

        public async Task<LoanInstallment> UpdateLoanInstallmentAsync(LoanInstallmentDTO dto)
        {
            return await _loanInstallmentRepository.UpdateLoanInstallment(dto);
        }

        public async Task<List<LoanInstallment>> GetLoanInstallmentsByDisbursementIdAsync(int disbursementId)
        {
            return await _loanInstallmentRepository.GetLoanInstallmentsByDisbursementIdAsync(disbursementId);
        }
    }
}
