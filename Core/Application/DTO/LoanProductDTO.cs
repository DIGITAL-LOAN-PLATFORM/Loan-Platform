namespace Application.DTO
{
    public class CreateLoanProductDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal InterestRate { get; set; }
    }

    public class UpdateLoanProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal InterestRate { get; set; }
    }

    public class DeleteLoanProductDTO
    {
        public int Id { get; set; }
    }

    public class LoanProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal InterestRate { get; set; }
    }
}