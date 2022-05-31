namespace HouseDemo.Core.Service;
public class HouseService
{
    public HouseResult AddHouse(HouseRequest request)
    {
        return new HouseResult {
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