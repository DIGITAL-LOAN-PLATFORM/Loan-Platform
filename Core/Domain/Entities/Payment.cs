using Domain.Entities;
namespace Domain.Entities
{
     public class Payment
     {
        public int Id { get; set; }
        public int LoanDisbursmentId { get; set; }
        public LoanDisbursment? LoanDisbursment { get; set; }
        public  decimal TotalAmountPaid  { get; set; }
        public decimal? PenaltyAllocated { get; set; }
        public PaymentType? PaymentType{ get; set;}
        public Account? Account{ get; set;}
        public DateTime? PaymentDate {get;set;}
        
    }
}