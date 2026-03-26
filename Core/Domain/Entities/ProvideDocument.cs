using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities
{
      public class ProvidedDocument
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        [ForeignKey("LoanId")]
        public LoanApplication LoanApplication { get; set; }
        public string DocumentName { get; set; }
        public string DocumentFile { get; set;}
        public DateTime CreatedAt { get; set; }
    }
}