
namespace HouseDemo.Core.Service;

public class HouseServiceTests
{
    private readonly HouseService _service;

    public HouseServiceTests()
    {
        _service = new HouseService();
    }

    [Fact]
    public void ShouldReturnHouseResultWithRequestValues()
    {
        //Arrange
        var request = new HouseRequest
        {
            HouseName = "海洋都心二期影城美裝三房",
            Address = "新北市淡水區新市三路二段",
            Description = "鄰新市鎮美麗新影城、輕軌V10站、商業區社區管理優質，適合小家庭，淡海新市鎮各項建設持續規劃中，未來潛力無限。",
            Price = 1088,
            DiscountRate = 0.15f,
            HouseType = HouseType.ElevatorBuilding,
            Years = 4.0f,
            MinFloor = 6,
            MaxFloor = 6,
            TotalFloor = 29,
            Rooms = 2,
            LivinigRooms = 1,
            Bathrooms = 1,
            HasBalcony = true,
            MainSpace = 21.76f,
            LandSpace = 2.96f,
            BuildingSpace = 41.51f,
            ParkingSpace = 4.608f,
        };

        // Act
        HouseResult result = _service.AddHouse(request);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(request.HouseName, result.HouseName);
        Assert.Equal(request.Address, result.Address);
        Assert.Equal(request.Description, result.Description);
        Assert.Equal(request.Price, result.Price);
        Assert.Equal(request.DiscountRate, result.DiscountRate);
        Assert.Equal(request.HouseType, result.HouseType);
        Assert.Equal(request.Years, result.Years);
        Assert.Equal(request.MinFloor, result.MinFloor);
        Assert.Equal(request.MaxFloor, result.MaxFloor);
        Assert.Equal(request.TotalFloor, result.TotalFloor);
        Assert.Equal(request.Rooms, result.Rooms);
        Assert.Equal(request.LivinigRooms, result.LivinigRooms);
        Assert.Equal(request.Bathrooms, result.Bathrooms);
        Assert.Equal(request.HasBalcony, result.HasBalcony);
        Assert.Equal(request.MainSpace, result.MainSpace);
        Assert.Equal(request.LandSpace, result.LandSpace);
        Assert.Equal(request.BuildingSpace, result.BuildingSpace);
        Assert.Equal(request.ParkingSpace, result.ParkingSpace);
    }
}

