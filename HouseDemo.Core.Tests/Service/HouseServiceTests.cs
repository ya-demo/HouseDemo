
namespace HouseDemo.Core.Service;

public class HouseServiceTests
{
    private readonly Mock<IHouseRepository> _houseRepositoryMock;
    private readonly HouseRequest _request;
    private readonly HouseService _service;

    public HouseServiceTests()
    {
        _request = new HouseRequest
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
            LivingRooms = 1,
            Bathrooms = 1,
            HasBalcony = true,
            MainSpace = 21.76f,
            LandSpace = 2.96f,
            BuildingSpace = 41.51f,
            ParkingSpace = 4.608f,
        };
        _houseRepositoryMock = new Mock<IHouseRepository>();
        _service = new HouseService(_houseRepositoryMock.Object);
    }

    [Fact]
    public async Task AddHouseShouldThrowExceptionIfRequestIsNull()
    {
        var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.AddHouse(null));
        Assert.Equal("request", exception.ParamName);
    }

    [Fact]
    public async Task AddHouseShouldReturnHouseResultWithRequestValues()
    {
        HouseResult result = await _service.AddHouse(_request);
        
        Assert.NotNull(result);
        Assert.Equal(_request.HouseName, result.HouseName);
        Assert.Equal(_request.Address, result.Address);
        Assert.Equal(_request.Description, result.Description);
        Assert.Equal(_request.Price, result.Price);
        Assert.Equal(_request.DiscountRate, result.DiscountRate);
        Assert.Equal(_request.HouseType, result.HouseType);
        Assert.Equal(_request.Years, result.Years);
        Assert.Equal(_request.MinFloor, result.MinFloor);
        Assert.Equal(_request.MaxFloor, result.MaxFloor);
        Assert.Equal(_request.TotalFloor, result.TotalFloor);
        Assert.Equal(_request.Rooms, result.Rooms);
        Assert.Equal(_request.LivingRooms, result.LivingRooms);
        Assert.Equal(_request.Bathrooms, result.Bathrooms);
        Assert.Equal(_request.HasBalcony, result.HasBalcony);
        Assert.Equal(_request.MainSpace, result.MainSpace);
        Assert.Equal(_request.LandSpace, result.LandSpace);
        Assert.Equal(_request.BuildingSpace, result.BuildingSpace);

    }

    [Fact]
    public async Task AddHouseShouldSaveHouse()
    {
        House savedHouse = null;
        _houseRepositoryMock.Setup(x => x.AddHouse(It.IsAny<House>()))
          .Callback<House>(house =>
          {
             savedHouse = house;
          });

        await _service.AddHouse(_request);
        _houseRepositoryMock.Verify(x => x.AddHouse(It.IsAny<House>()), Times.Once);

        Assert.NotNull(savedHouse);
        Assert.Equal(_request.HouseName, savedHouse.HouseName);
        Assert.Equal(_request.Address, savedHouse.Address);
        Assert.Equal(_request.Description, savedHouse.Description);
        Assert.Equal(_request.Price, savedHouse.Price);
        Assert.Equal(_request.DiscountRate, savedHouse.DiscountRate);
        Assert.Equal(_request.HouseType, savedHouse.HouseType);
        Assert.Equal(_request.Years, savedHouse.Years);
        Assert.Equal(_request.MinFloor, savedHouse.MinFloor);
        Assert.Equal(_request.MaxFloor, savedHouse.MaxFloor);
        Assert.Equal(_request.TotalFloor, savedHouse.TotalFloor);
        Assert.Equal(_request.Rooms, savedHouse.Rooms);
        Assert.Equal(_request.LivingRooms, savedHouse.LivingRooms);
        Assert.Equal(_request.Bathrooms, savedHouse.Bathrooms);
        Assert.Equal(_request.HasBalcony, savedHouse.HasBalcony);
        Assert.Equal(_request.MainSpace, savedHouse.MainSpace);
        Assert.Equal(_request.LandSpace, savedHouse.LandSpace);
        Assert.Equal(_request.BuildingSpace, savedHouse.BuildingSpace);
        Assert.Equal(_request.ParkingSpace, savedHouse.ParkingSpace);
    }

    [Theory]
    [InlineData("ea3881d8-7cf7-45ba-b930-d915f6f08fd0", "test1")]
    [InlineData("1f85ccc2-6572-4840-8deb-260e8635762c", "test2")]
    public async Task AddHouseShouldReturnExpectedHouseIdAndUserAndUpdatedTime(
        Guid houseId, string user)
    {
        House savedHouse = null;
        _houseRepositoryMock.Setup(x => x.AddHouse(It.IsAny<House>()))
          .Callback<House>(house =>
          {
              house.HouseId = houseId;
              house.CreatedTime = DateTime.Now;
              house.HouseName = user;
              savedHouse = house;
          });


        var result = await _service.AddHouse(_request);

        Assert.Equal(savedHouse.HouseId, result.HouseId);
        Assert.Equal(savedHouse.CreatedTime, result.CreatedTime);
        Assert.Equal(savedHouse.CreatedUser, result.CreatedUser);
        Assert.Equal(savedHouse.UpdatedTime, result.UpdatedTime);
        Assert.Equal(savedHouse.UpdatedUser, result.UpdatedUser);
        Assert.Null(result.DeletedTime);
        Assert.Null(result.DeletedUser);
    }
}

