namespace Domain.Entities
{
    public class LoanProductSetting
    {
        public int Id { get; set; }
        public int LoanProductId { get; set; }
        public LoanProduct? LoanProduct { get; set; }
        public decimal InterestRate { get; set; }
        public decimal MaintenanceFee { get; set; }
        public decimal ProcessingFee { get; set; }
        public decimal InsuranceFee { get; set; }
        public string Status { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}