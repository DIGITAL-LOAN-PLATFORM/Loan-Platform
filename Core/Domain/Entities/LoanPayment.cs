using Domain.Entities;

namespace Domain.Entities
{
    public class LoanPayment
    {
        public int Id { get; set; }
        public int LoanInstallmentId { get; set; }
        public LoanInstallment? LoanInstallment { get; set; }
        
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMode { get; set; } = string.Empty;
        public string ReferenceNumber { get; set; } = string.Empty;
        
        public int? AccountId { get; set; }
        public Account? Account { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
