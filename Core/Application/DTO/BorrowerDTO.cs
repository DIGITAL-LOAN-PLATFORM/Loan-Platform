namespace Application.DTO
{
    public class CreateBorrowerDTO
    {
        public string IdentificationNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public string MaritalStatus { get; set; } = string.Empty;
        public string SpouseName { get; set; } = string.Empty;
        public string SpouseId { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public string Cell { get; set; } = string.Empty;
        public string Village { get; set; } = string.Empty;
    }

    public class UpdateBorrowerDTO
    {
        public int Id { get; set; }
        public string IdentificationNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public string MaritalStatus { get; set; } = string.Empty;
        public string SpouseName { get; set; } = string.Empty;
        public string SpouseId { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public string Cell { get; set; } = string.Empty;
        public string Village { get; set; } = string.Empty;
    }

    public class DeleteBorrowerDTO
    {
        public int Id { get; set; }
    }
}