namespace Domain.Entities
{
    public class RequiredDocument
    {
        public int Id { get; set; }
        public string DocumentName { get; set; } = string.Empty;
        public string DocumentType { get; set; } = string.Empty;
        public string DocumentFile { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}