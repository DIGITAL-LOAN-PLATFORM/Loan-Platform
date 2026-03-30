using Domain.Entities;

namespace Application.DTO
{
    public class CreateLoanDisbursmentDTO
    {
        public int LoanApplicationId { get; set; }
        public int PaymentModalityId { get; set; }
        public int AccountId { get; set; }
        public decimal DisbursedAmount { get; set; }
        public string PaymentMode { get; set; } = string.Empty;
        public string ReferenceNumber { get; set; } = string.Empty;
        public decimal InterestRate { get; set; }
        public decimal TotalRepaymentAmount { get; set; }
        public DateTime DisbursementDate { get; set; }
        public DateTime InterestClockStartDate { get; set; }
        public DateTime InterestClockEndDate { get; set; }
    }

    public class UpdateLoanDisbursmentDTO
    {
        public int Id { get; set; }
        public int LoanApplicationId { get; set; }
        public int PaymentModalityId { get; set; }
        public int AccountId { get; set; }
        public decimal DisbursedAmount { get; set; }
        public decimal InterestRate { get; set; }
        public decimal TotalRepaymentAmount { get; set; }
        public string PaymentMode { get; set; } 
        public string ReferenceNumber { get; set; } 
        public DateTime DisbursementDate { get; set; }
        public DateTime InterestClockStartDate { get; set; }
        public DateTime InterestClockEndDate { get; set; }
    }

    public class GetLoanDisbursmentDTO
    {
        public int Id { get; set; }
        public int LoanApplicationId { get; set; }
        public int PaymentModalityId { get; set; }
        public int AccountId { get; set; }
        public decimal DisbursedAmount { get; set; }
        public decimal InterestRate { get; set; }
        public decimal TotalRepaymentAmount { get; set; }
        public string PaymentMode { get; set; } 
        public string ReferenceNumber { get; set; } 
        public DateTime DisbursementDate { get; set; }
        public DateTime InterestClockStartDate { get; set; }
        public DateTime InterestClockEndDate { get; set; }
    }

    public class DeleteLoanDisbursmentDTO
    {
        public int Id { get; set; }
    }
}