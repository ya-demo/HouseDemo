using HouseDemo.DataAccess.Models;

namespace HouseDemo.DataAccess.Repositories.Interfaces;

public interface IHouseRepository
{
    Task AddHouse(House house);
    Task<IEnumerable<House>> GetHouses(HouseQueryRequest request);
    Task<House> GetHouse(Guid id);
}

