namespace Application.DTO
{
    public class CreateRequiredDocumentDTO
    {
        public int LoanProductId { get; set; }
        public string DocumentName { get; set; } = string.Empty;
        public string DocumentType { get; set; } = string.Empty;
    }

    public class UpdateRequiredDocumentDTO
    {
        public int Id { get; set; }
        public int LoanProductId { get; set; }
        public string DocumentName { get; set; } = string.Empty;
        public string DocumentType { get; set; } = string.Empty;
    }
    
    public class DeleteRequiredDocumentDTO
    {
        public int Id { get; set; }
    }
}