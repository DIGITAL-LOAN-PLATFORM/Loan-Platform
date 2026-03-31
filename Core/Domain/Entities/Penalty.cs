using Domain.Entities;
namespace Domain.Entities
{
     public class Penalty
    {
        public int Id { get; set; }
        public int LoanDisbursmentId { get; set; }
        public LoanDisbursment LoanDisbursment { get; set; }
        public decimal PenaltyAmount { get; set; }
        public int ReasonId { get; set; }
        public Reason Reason { get; set; }
        public string ConfirmedByUserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
       
    }
}