using Domain.Entities;
namespace Domain.Entities
{
    public class LoanRecquirements
    {

        public int Id { get; set; }
        public RequiredDocument RequiredDocument{ get; set; }
        public LoanProduct  LoanProduct { get; set; }
        public int RequiredDocumentId { get; set; }
        public int LoanProductId { get; set; }
         public DateTime CreatedAt { get; set; }
    }
}