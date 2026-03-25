using Domain.Entities;
namespace Domain.Entities
{
      public class ProvidedDocument
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public LoanApplication LoanApplication { get; set; }
        public string DocumentName { get; set; }
        public string DocumentFile { get; set;}
        public DateTime CreatedAt { get; set; }
    }
}