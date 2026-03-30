using Domain.Entities;

namespace Application.DTO
{
    public class CreateGuarantorDTO
    {
        public string IdentificationNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public GuarantorType? GuarantorType { get; set; }

        // Administrative location hierarchy
        public string Province { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public string Cell { get; set; } = string.Empty;
        public string Village { get; set; } = string.Empty;
        
    }

    public class UpdateGuarantorDTO
    {
        public int Id { get; set; }
        public string IdentificationNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public GuarantorType? GuarantorType { get; set; }

        // Administrative location hierarchy
        public string Province { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public string Cell { get; set; } = string.Empty;
        public string Village { get; set; } = string.Empty;
    }

    public class DeleteGuarantorDTO
    {
        public int Id { get; set; }
    }
}
