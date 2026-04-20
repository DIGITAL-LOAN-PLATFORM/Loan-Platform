using Domain.Entities;
namespace Application.DTO
{
    public class CreateCollateralDTO
    {
        public string AssetName { get; set; }
        public string AssetType { get; set; }
        public decimal EstimatedValue { get; set; }
        public string IdentificationNumber { get; set; } 
        public int LoanApplicationId { get; set; }
        public LoanApplication LoanApplication { get; set; }
        public string Description { get; set; }
        public string ValuerName { get; set; }
        public DateTime ValuationDate { get; set; }
        
        //Administrative location hierarchy
        public string Province {get;set;}
        public string District {get;set;}
        public string Sector {get;set;}
        public string Cell {get;set;}
        public string Village {get;set;}
    }

    public class UpdateCollateralDTO
    {
        public int Id { get; set; }
        public string AssetName { get; set; }
        public string AssetType { get; set; }
        public decimal EstimatedValue { get; set; }
        public string IdentificationNumber { get; set; } 
        public int LoanApplicationId { get; set; }
        public LoanApplication LoanApplication { get; set; }
        public string Description { get; set; }
        public string ValuerName { get; set; }
        public DateTime ValuationDate { get; set; }
        
        //Administrative location hierarchy
        public string Province {get;set;}
        public string District {get;set;}
        public string Sector {get;set;}
        public string Cell {get;set;}
        public string Village {get;set;}
    }

    // public class DeleteBorrowerDTO
    // {
    //     public int Id { get; set; }
    // }
}