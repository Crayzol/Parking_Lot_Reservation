using Microsoft.EntityFrameworkCore.Migrations;

namespace Parking_Lot_Reservation.Migrations
{
    public partial class Add_charger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCharger",
                table: "ParkingSpaces",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCharger",
                table: "ParkingSpaces");
        }
    }
}
