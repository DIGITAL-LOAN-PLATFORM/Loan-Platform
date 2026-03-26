using Domain.Entities;
namespace Domain.Entities
{
     public class Guarantor
    {
        public int Id { get; set; }
        public string? IdentificationNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? DOB { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        // Administrative location hierarchy
        public string Province { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public string Cell { get; set; } = string.Empty;
        public string Village { get; set; } = string.Empty;
        
        public GuarantorType? GuarantorType { get; set; }
    }
}