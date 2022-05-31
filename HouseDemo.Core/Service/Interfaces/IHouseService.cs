using HouseDemo.Common.PageExtention;

namespace HouseDemo.Core.Service.Interface;

public interface IHouseService
{
    Task<HouseResult> AddHouse(HouseRequest request);
    Task<PageResult<HouseResult>> GetHouses(HouseQueryRequest request);
    Task<HouseResult> GetHouse(Guid id);
    Task<HouseResult> UpdateHouse(Guid id, HouseRequest request);
    Task DeleteHouse(Guid id);
}