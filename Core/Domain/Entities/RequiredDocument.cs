using Domain.ValueObjects;
namespace Domain.Entities
{
    public class RequiredDocument
    {
        public int Id { get; set; }
        public int LoanProductId { get; set; }
        public LoanProduct LoanProduct { get; set; }
        public string DocumentName { get; set; } = string.Empty;
        public DocumentType DocumentType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}