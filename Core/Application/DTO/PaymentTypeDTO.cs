namespace Application.DTO
{
    public class CreatePaymentTypeDTO
    {
        public string Name { get; set; } = string.Empty;
    }
    public class UpdatePaymentTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class DeletePaymentTypeDTO
    {
        public int Id { get; set; }
    }
}