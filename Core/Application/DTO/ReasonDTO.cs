namespace Application.DTO
{
    public class CreateReasonDTO
    {
        public string Name { get; set; } = string.Empty;
    }

    public class UpdateReasonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class DeleteReasonDTO
    {
        public int Id { get; set; }
    }
}
