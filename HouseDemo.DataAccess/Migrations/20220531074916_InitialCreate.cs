using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseDemo.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "房屋Id"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "創建時間"),
                    CreatedUser = table.Column<string>(type: "varchar(50)", nullable: false, comment: "創建者"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "修改時間"),
                    UpdatedUser = table.Column<string>(type: "varchar(50)", nullable: false, comment: "修改者"),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "刪除時間"),
                    DeletedUser = table.Column<string>(type: "varchar(50)", nullable: true, comment: "刪除者"),
                    HouseName = table.Column<string>(type: "varchar(20)", nullable: false, comment: "房屋名稱"),
                    Address = table.Column<string>(type: "varchar(100)", nullable: false, comment: "地址"),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true, comment: "描述"),
                    Price = table.Column<int>(type: "int", nullable: false, comment: "價格"),
                    DiscountRate = table.Column<double>(type: "float", nullable: true, comment: "折扣率"),
                    HouseType = table.Column<int>(type: "int", nullable: false, comment: "房屋類型"),
                    Years = table.Column<double>(type: "float", nullable: false, comment: "年"),
                    MinFloor = table.Column<int>(type: "int", nullable: false, comment: "最低樓層"),
                    MaxFloor = table.Column<int>(type: "int", nullable: false, comment: "最高樓層"),
                    TotalFloor = table.Column<int>(type: "int", nullable: false, comment: "總樓層"),
                    Rooms = table.Column<int>(type: "int", nullable: false, comment: "房間數"),
                    LivinigRooms = table.Column<int>(type: "int", nullable: false, comment: "廳數"),
                    Bathrooms = table.Column<int>(type: "int", nullable: false, comment: "衛浴數"),
                    HasBalcony = table.Column<bool>(type: "bit", nullable: false, comment: "是否有陽台"),
                    LandSpace = table.Column<double>(type: "float", nullable: false, comment: "土地坪數"),
                    MainSpace = table.Column<double>(type: "float", nullable: false, comment: "主坪數"),
                    BuildingSpace = table.Column<double>(type: "float", nullable: false, comment: "建物坪數"),
                    ParkingSpace = table.Column<double>(type: "float", nullable: true, comment: "車位坪數")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.HouseId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "標籤Id"),
                    TagName = table.Column<string>(type: "varchar(20)", nullable: false, comment: "標籤名稱"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "創建時間"),
                    CreatedUser = table.Column<string>(type: "varchar(50)", nullable: false, comment: "創建者"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "修改時間"),
                    UpdatedUser = table.Column<string>(type: "varchar(50)", nullable: false, comment: "修改者"),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "刪除時間"),
                    DeletedUser = table.Column<string>(type: "varchar(50)", nullable: true, comment: "刪除者")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "HouseTags",
                columns: table => new
                {
                    HouseTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FkHouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FkTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseTags", x => x.HouseTagId);
                    table.ForeignKey(
                        name: "FK_HouseTags_Houses_FkHouseId",
                        column: x => x.FkHouseId,
                        principalTable: "Houses",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseTags_Tags_FkTagId",
                        column: x => x.FkTagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HouseTags_FkHouseId",
                table: "HouseTags",
                column: "FkHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseTags_FkTagId",
                table: "HouseTags",
                column: "FkTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseTags");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
