using Domain.Entities;

namespace Application.DTO
{
    public class CreateLoanPaymentDTO
    {
        public int LoanInstallmentId { get; set; }
        public int AccountId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMode { get; set; } = string.Empty;
        public string ReferenceNumber { get; set; } = string.Empty;
    }

    public class LoanPaymentDTO
    {
        public int Id { get; set; }
        public int LoanInstallmentId { get; set; }
        public int AccountId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMode { get; set; } = string.Empty;
        public string ReferenceNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
