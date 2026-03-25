using Domain.Entities;
namespace Domain.Entities
{
      public class LoanApplication
    {
        public Guid Id { get; set; }
        public string ApplicationNumber { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public LoanProduct? loanProduct{ get; set; }
        public int BorrowerId { get; set; }
        public Borrower? Borrower{ get; set; }
        public int ModalityId { get; set;}
        public PaymentModality? paymentModality { get; set; }
        public decimal RequestedAmount { get; set;}
        public int Duration { get; set;}
        public string? Purpose {get; set; }
        public DateTime ApplicationDate { get; set; }
        public List<Guarantor> Guarantors { get; set; } = new();
        public List<ProvidedDocument> ProvidedDocuments { get; set; } = new();


        //approval of status
        public string ApprovalStatus { get; set; } = "Pending";
        public DateTime ApprovalDate { get; set; }
        public string ApprovalBy { get; set; }
        public string ApprovalComments { get; set; }

        //rejection
        public DateTime RejectionDate { get; set; }
        public string RejectionBy { get; set; }
        public string RejectionComments { get; set; }

    }
}