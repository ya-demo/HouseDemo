
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

    public async Task<IEnumerable<House>> GetHouses(HouseQueryRequest request)
    {
        var sqlBuilder = new SqlBuilder();
        var sql = @"SELECT HouseId, HouseName, Address, Description ,
                    Price, DiscountRate, HouseType, Years, MinFloor, 
                    MaxFloor, TotalFloor, Rooms, LivingRooms, 
                    Bathrooms, HasBalcony, LandSpace, MainSpace, 
                    BuildingSpace, ParkingSpace, CreatedTime, CreatedUser, UpdatedTime, UpdatedUser
                    FROM Houses /**where**/
                    ORDER BY CreatedTime DESC";
        var selector = sqlBuilder.AddTemplate(sql);
        sqlBuilder.Where("DeletedTime is null");
        if (request != null && !String.IsNullOrEmpty(request.Filter))
        {
            request.Filter = $"%{request.Filter}%";
            sqlBuilder.Where("HouseName like @filter", new { request.Filter });
        }

        using (var conn = new SqlConnection(_configuration.GetSection("ConnectionStrings")["MsSql"]))
        {
            return await conn.QueryAsync<House>(selector.RawSql, selector.Parameters);
        }
    }

    public async Task<House> GetHouse(Guid id)
    {
        var sql = @"SELECT HouseId, HouseName, Address, Description ,
                    Price, DiscountRate, HouseType, Years, MinFloor, 
                    MaxFloor, TotalFloor, Rooms, LivingRooms, 
                    Bathrooms, HasBalcony, LandSpace, MainSpace, 
                    BuildingSpace, ParkingSpace, CreatedTime, CreatedUser, UpdatedTime, UpdatedUser
                    FROM Houses
                    WHERE DeletedTime is null and HouseId = @HouseId";

        using (var conn = new SqlConnection(_configuration.GetSection("ConnectionStrings")["MsSql"]))
        {
            return await conn.QueryFirstOrDefaultAsync<House>(sql, new { HouseId = id });
        }
    }

}

