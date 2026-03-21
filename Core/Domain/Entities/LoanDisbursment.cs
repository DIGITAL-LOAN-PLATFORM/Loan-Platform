using Domain.Entities;
namespace Domain.Entities
{
    public class LoanDisbursement
    {
        public int Id { get; set; }
        public int LoanApplicationId { get; set; }
        public LoanApplication? LoanApplication { get; set; }
        public PaymentModality? PaymentModality { get; set; }
        public decimal DisbursedAmount { get; set; }
        public string? PaymentMode { get; set; }
        public string? ReferenceNumber { get; set; } = string.Empty;
        public decimal? principalOffered { get; set; }
        public DateTime? DisbursementDate { get; set; }
        public DateTime? InterestClockStartDate { get; set; }
        public DateTime? InterestClockEndDate { get; set; }
        public decimal? InterestRate { get; set; }
    }
}