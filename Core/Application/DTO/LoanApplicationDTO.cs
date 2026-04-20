using Domain.Entities;
namespace Application.DTO
{
    public class DocumentUploadDTO
    {
        public string DocumentName { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string Base64Content { get; set; } = string.Empty;
    }

    public class CreateLoanApplicationDTO
    {
        public string ApplicationNumber { get; set; }
        public int ProductId { get; set; }
        public int BorrowerId { get; set; }
        public int ModalityId { get; set; }
        public decimal RequestedAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int Duration { get; set; }
        public string? Purpose { get; set; }
        public DateTime ApplicationDate { get; set; }
        public List<DocumentUploadDTO> ProvidedDocuments { get; set; } = new();
    }

    public class UpdateLoanApplicationDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BorrowerId { get; set; }
        public int ModalityId { get; set; }
        public decimal RequestedAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int Duration { get; set; }
        public string? Purpose { get; set; }
        public DateTime ApplicationDate { get; set; }
        public List<DocumentUploadDTO> ProvidedDocuments { get; set; } = new();
    }

    public class GetLoanApplicationDTO
    {
        public int Id { get; set; }
        public string ApplicationNumber { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public LoanProduct? loanProduct { get; set; }
        public int BorrowerId { get; set; }
        public Borrower? Borrower { get; set; }
        public int ModalityId { get; set; }
        public PaymentModality? paymentModality { get; set; }
        public decimal RequestedAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int Duration { get; set; }
        public string? Purpose { get; set; }
        public DateTime ApplicationDate { get; set; }
        public List<ProvidedDocument> ProvidedDocuments { get; set; } = new();
        public List<Guarantor> Guarantors { get; set; } = new();

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