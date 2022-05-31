
namespace HouseDemo.DataAccess.Models;

public class HouseBase
{
    public string HouseName { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public float DiscountRate { get; set; }
    public HouseType HouseType { get; set; }
    public float Years { get; set; }
    public int MinFloor { get; set; }
    public int MaxFloor { get; set; }
    public int TotalFloor { get; set; }
    public int Rooms { get; set; }
    public int LivinigRooms { get; set; }
    public int Bathrooms { get; set; }
    public bool HasBalcony { get; set; }
    public float LandSpace { get; set; }
    public float MainSpace { get; set; }
    public float BuildingSpace { get; set; }
    public float ParkingSpace { get; set; }
}


