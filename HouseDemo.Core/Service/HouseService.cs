namespace HouseDemo.Core.Service;

public class HouseService
{
    private readonly IHouseRepository _houseRepository;

    public HouseService(IHouseRepository houseRepository) {
        _houseRepository = houseRepository;
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

    private static T Create<T>(HouseRequest request) where T : HouseBase, new()
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
            LivinigRooms = request.LivinigRooms,
            Bathrooms = request.Bathrooms,
            HasBalcony = request.HasBalcony,
            MainSpace = request.MainSpace,
            LandSpace = request.LandSpace,
            BuildingSpace = request.BuildingSpace,
            ParkingSpace = request.ParkingSpace,
        };
    }
}