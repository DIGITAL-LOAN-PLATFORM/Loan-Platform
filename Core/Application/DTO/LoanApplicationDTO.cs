using Domain.Entities;
namespace Application.DTO
{
    public class CreateLoanApplicationDTO
    {
        public int ProductId { get; set; }
        public int BorrowerId { get; set; }
        public int ModalityId { get; set;}
        public decimal RequestedAmount { get; set;}
        public string? Purpose {get; set; }
        public DateTime PreferedDate { get; set; }
        public List<Guarantor> Guarantors { get; set; } = new();
    }

    public class UpdateLoanApplicationDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BorrowerId { get; set; }
        public int ModalityId { get; set;}
        public decimal RequestedAmount { get; set;}
        public string? Purpose {get; set; }
        public DateTime PreferedDate { get; set; }
        public List<Guarantor> Guarantors { get; set; } = new();
    }

    public class GetLoanApplicationDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BorrowerId { get; set; }
        public int ModalityId { get; set;}
        public decimal RequestedAmount { get; set;}
        public string? Purpose {get; set; }
        public DateTime PreferedDate { get; set; }
        public List<Guarantor> Guarantors { get; set; } = new();
    }
}