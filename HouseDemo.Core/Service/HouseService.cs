using HouseDemo.Common.PageExtention;

namespace HouseDemo.Core.Service;

public class HouseService : IHouseService
{
    private readonly IHouseRepository _houseRepository;

    public HouseService(IHouseRepository houseRepository) {
        _houseRepository = houseRepository;
    }


    public async Task<PageResult<HouseResult>> GetHouses(HouseQueryRequest request)
    {
        var houses = await _houseRepository.GetHouses(request);
        var result = houses.Select(house =>
        {
            var tmpHouse = Create<HouseResult>(house);
            tmpHouse.HouseId = house.HouseId;
            tmpHouse.CreatedTime = house.CreatedTime;
            tmpHouse.CreatedUser = house.CreatedUser;
            tmpHouse.UpdatedTime = house.UpdatedTime;
            tmpHouse.UpdatedUser = house.UpdatedUser;
            return tmpHouse;
        }).ToList();

        return result.Pages(request.Rows, request.Page);
    }

    public async Task<HouseResult> GetHouse(Guid id)
    {
        var house = await _houseRepository.GetHouse(id);
        if (house == null)
            throw new Exception($"找不到 {id} 的資料");
        var result = Create<HouseResult>(house);
        result.HouseId = house.HouseId;
        result.CreatedTime = house.CreatedTime;
        result.CreatedUser = house.CreatedUser;
        result.UpdatedTime = house.UpdatedTime;
        result.UpdatedUser = house.UpdatedUser;

        return result;
    }

    public async Task<HouseResult> AddHouse(HouseRequest request)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var now = DateTime.UtcNow;

        var house = Create<House>(request);
        house.HouseId = Guid.NewGuid();
        house.CreatedUser = "Sys";
        house.CreatedTime = now;
        house.UpdatedUser = "Sys";
        house.UpdatedTime = now;
        await _houseRepository.AddHouse(house);

        var result = Create<HouseResult>(request);
        result.HouseId = house.HouseId;
        result.CreatedUser = house.CreatedUser;
        result.CreatedTime = house.CreatedTime;
        result.UpdatedUser = house.UpdatedUser;
        result.UpdatedTime = house.UpdatedTime;

        return result;
    }

    public async Task<HouseResult> UpdateHouse(Guid id, HouseRequest request)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var now = DateTime.UtcNow;

        var house = Create<House>(request);
        house.HouseId = id;
        house.UpdatedUser = "Sys";
        house.UpdatedTime = now;
        await _houseRepository.UpdateHouse(house);

        var result = Create<HouseResult>(request);
        result.HouseId = house.HouseId;
        result.UpdatedUser = house.UpdatedUser;
        result.UpdatedTime = house.UpdatedTime;

        return result;
    }

    public async Task DeleteHouse(Guid id)
    {
        var now = DateTime.UtcNow;
        var house = new House {
           HouseId = id,
            UpdatedUser = "Sys",
            UpdatedTime = now,
            DeletedUser = "Sys",
            DeletedTime = now,
         };

        await _houseRepository.DeleteHouse(house);
    }

    private static T Create<T>(HouseBase request) where T : HouseBase, new()
    {
        return new T
        {
            HouseName = request.HouseName,
            Address = request.Address,
            Description = request.Description,
            Price = request.Price,
            DiscountRate = request.DiscountRate,
            HouseType = request.HouseType,
            Years = request.Years,
            MinFloor = request.MinFloor,
            MaxFloor = request.MaxFloor,
            TotalFloor = request.TotalFloor,
            Rooms = request.Rooms,
            LivingRooms = request.LivingRooms,
            Bathrooms = request.Bathrooms,
            HasBalcony = request.HasBalcony,
            MainSpace = request.MainSpace,
            LandSpace = request.LandSpace,
            BuildingSpace = request.BuildingSpace,
            ParkingSpace = request.ParkingSpace,
        };
    }
}