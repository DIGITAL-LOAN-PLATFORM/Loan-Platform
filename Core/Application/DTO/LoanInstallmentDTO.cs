using Domain.Entities;

namespace Application.DTO
{
    public class LoanInstallmentDTO
    {
        public int Id { get; set; }
        public int LoanDisbursmentId { get; set; }
        
        public DateTime DueDate { get; set; }
        public decimal AmountDue { get; set; }
        public decimal PenaltyAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public string Status { get; set; } = "Pending";
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
