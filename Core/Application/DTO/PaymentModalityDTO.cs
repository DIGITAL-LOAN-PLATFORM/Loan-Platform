namespace Application.DTO
{
    public class CreatePaymentModalityDTO
    {
        public string Name { get; set; } = string.Empty;
    }

    public class UpdatePaymentModalityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class DeletePaymentModalityDTO
    {
        public int Id { get; set; }
    }
}
