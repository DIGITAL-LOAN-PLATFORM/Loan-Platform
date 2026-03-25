using Domain.Entities;

namespace Application.Interfaces;

public interface ILocationService
{
    //Get All
    Task<List<Province>> GetAllLocationsAsync();
}
