using Domain.Entities;
namespace Domain.Entities
{
      public class LoanApplication
    {
        public int Id { get; set; }
        public string ApplicationNumber { get; set; } = string.Empty;
        public int ProductSettingId { get; set; }
        public LoanProductSetting? LoanProductSetting { get; set; }
        public int BorrowerId { get; set; }
        public Borrower? Borrower { get; set; }
        public int ModalityId { get; set; }
        public PaymentModality? PaymentModality { get; set; }
        public decimal RequestedAmount { get; set;}
        public decimal InterestRate { get; set; }
        public decimal MaintenanceFee { get; set; }
        public decimal ProcessingFee { get; set; }
        public decimal InsuranceFee { get; set; }
        public int Duration { get; set;}
        public string? Purpose {get; set; }
        public DateTime ApplicationDate { get; set; }
        public List<ProvidedDocument> ProvidedDocuments { get; set; } = new();
        public List<Guarantor> Guarantors { get; set; } = new();


        //approval of status
        public string ApprovalStatus { get; set; } = "Pending";
        public DateTime? ApprovalDate { get; set; }
        public string? ApprovalBy { get; set; }
        public string? ApprovalComments { get; set; }

        //rejection
        public DateTime? RejectionDate { get; set; }
        public string? RejectionBy { get; set; }
        public string? RejectionComments { get; set; }

    }
}