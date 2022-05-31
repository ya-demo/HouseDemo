
using Dapper;
using HouseDemo.DataAccess.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HouseDemo.DataAccess.Repositories;

public class HouseRepository : IHouseRepository
{
    private readonly IConfiguration _configuration;
    public HouseRepository(IConfiguration configuration) {
        _configuration = configuration;
    }

    public async Task AddHouse(House house)
    {
        var sql = @"INSERT INTO Houses(HouseId, HouseName, Address, Description , Price, DiscountRate, HouseType, Years, MinFloor, MaxFloor, TotalFloor, Rooms, LivingRooms, Bathrooms, HasBalcony, LandSpace, MainSpace, BuildingSpace, ParkingSpace, CreatedTime, CreatedUser, UpdatedTime, UpdatedUser)
            VALUES(@HouseId, @HouseName, @Address, @Description , @Price, @DiscountRate, @HouseType, @Years, @MinFloor, @MaxFloor, @TotalFloor, @Rooms, @LivingRooms, @Bathrooms, @HasBalcony, @LandSpace, @MainSpace, @BuildingSpace, @ParkingSpace, @CreatedTime, @CreatedUser, @UpdatedTime, @UpdatedUser)";
        using (var conn = new SqlConnection(_configuration.GetSection("ConnectionStrings")["MsSql"]))
        {
            await conn.ExecuteAsync(sql, house);
        }
    }
}

