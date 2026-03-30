using Domain.Entities;

namespace Domain.Entities
{
    public class LoanInstallment
    {
        public int Id { get; set; }
        public int LoanDisbursmentId { get; set; }
        public LoanDisbursment? LoanDisbursment { get; set; }
        
        public DateTime DueDate { get; set; }
        public decimal AmountDue { get; set; }
        public decimal PenaltyAmount { get; set; }
        public decimal AmountPaid { get; set; }
        
        // Status: "Pending", "Paid", "Partial", "Overdue"
        public string Status { get; set; } = "Pending";
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<LoanPayment> Payments { get; set; } = new List<LoanPayment>();
    }
}
