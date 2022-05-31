using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseDemo.DataAccess.Migrations
{
    public partial class FixLivingRoomWord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LivinigRooms",
                table: "Houses",
                newName: "LivingRooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LivingRooms",
                table: "Houses",
                newName: "LivinigRooms");
        }
    }
}
