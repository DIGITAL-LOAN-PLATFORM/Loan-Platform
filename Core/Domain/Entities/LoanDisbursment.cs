using Domain.Entities;
namespace Domain.Entities
{
    public class LoanDisbursment
    {
        public int Id { get; set; }
        public int LoanApplicationId { get; set; }
        public LoanApplication? LoanApplication { get; set; }
        public int PaymentModalityId { get; set; }
        public PaymentModality? PaymentModality { get; set; }
        public decimal DisbursedAmount { get; set; }
        public decimal InterestRate { get; set; }
        public decimal TotalRepaymentAmount { get; set; }
        
        public int? AccountId { get; set; }
        public Account? Account { get; set; }
        
        public string PaymentMode { get; set; } = string.Empty;
        public string ReferenceNumber { get; set; } = string.Empty;
        public DateTime DisbursementDate { get; set; }
        public DateTime InterestClockStartDate { get; set; }
        public DateTime InterestClockEndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}