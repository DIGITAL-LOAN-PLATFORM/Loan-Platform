namespace Application.DTO
{
    public class CreateGuarantorTypeDTO
    {
        public string Name { get; set; } = string.Empty;
    }

    public class UpdateGuarantorTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class DeleteGuarantorTypeDTO
    {
        public int Id { get; set; }
    }
}
