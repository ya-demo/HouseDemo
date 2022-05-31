namespace HouseDemo.Core.Service.Interface;

public interface IHouseService
{
    Task<HouseResult> AddHouse(HouseRequest request);
}