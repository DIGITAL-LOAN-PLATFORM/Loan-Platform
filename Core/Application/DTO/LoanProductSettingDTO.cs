using Domain.Entities;
namespace Application.DTO
{
    public class CreateLoanProductSettingDTO
    {
        public int Id { get; set; }
        public int LoanProductId { get; set; }
        public LoanProduct LoanProduct { get; set; }
        public decimal InterestRate { get; set; }
        public decimal MaintenanceFee { get; set; }
        public decimal ProcessingFee { get; set; }
        public decimal InsuranceFee { get; set; }
        public string Status { get; set; } = "Active";
        public DateTime CreatedAt { get; set; }
    }

    public class UpdateLoanProductSettingDTO
    {
        public int Id { get; set; }
        public int LoanProductId { get; set; }
        public LoanProduct? LoanProduct { get; set; }
        public decimal InterestRate { get; set; }
        public decimal MaintenanceFee { get; set; }
        public decimal ProcessingFee { get; set; }
        public decimal InsuranceFee { get; set; }
        public string Status { get; set; } = "Active";
        public DateTime UpdatedAt { get; set; }
    }

    public class DeleteLoanProductSettingDTO
    {
        public int Id { get; set; }
    }

    public class LoanProductSettingDTO
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