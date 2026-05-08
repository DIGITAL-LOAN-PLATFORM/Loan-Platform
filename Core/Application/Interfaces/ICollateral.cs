using Application.DTO;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface ICollateral
    {
        Task<List<Collateral>> GetAllCollateralsAsync();
        Task<Collateral?> GetCollateralByIdAsync(int id);
        Task CreateCollateralAsync(CollateralCreateDTO collateralCreateDTO);
        Task UpdateCollateralAsync(int id, CollateralUpdateDTO collateralUpdateDTO);
    }
}