using Microsoft.EntityFrameworkCore.Migrations;

namespace Parking_Lot_Reservation.Migrations
{
    public partial class HasChargerFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCharger",
                table: "ParkingSpaces",
                newName: "HasCharger");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HasCharger",
                table: "ParkingSpaces",
                newName: "IsCharger");
        }
    }
}
