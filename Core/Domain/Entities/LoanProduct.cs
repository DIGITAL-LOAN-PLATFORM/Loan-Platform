namespace Domain.Entities
{
    public class LoanProduct
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? InterestRate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}