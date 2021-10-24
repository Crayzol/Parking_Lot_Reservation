using Microsoft.EntityFrameworkCore.Migrations;

namespace Parking_Lot_Reservation.Migrations
{
    public partial class ForeignKeyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_ParkingSpaces_ParkingSpaceModel",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "ParkingSpaceModel",
                table: "People",
                newName: "ParkingSpaceId");

            migrationBuilder.RenameIndex(
                name: "IX_People_ParkingSpaceModel",
                table: "People",
                newName: "IX_People_ParkingSpaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_ParkingSpaces_ParkingSpaceId",
                table: "People",
                column: "ParkingSpaceId",
                principalTable: "ParkingSpaces",
                principalColumn: "ParkingSpaceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_ParkingSpaces_ParkingSpaceId",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "ParkingSpaceId",
                table: "People",
                newName: "ParkingSpaceModel");

            migrationBuilder.RenameIndex(
                name: "IX_People_ParkingSpaceId",
                table: "People",
                newName: "IX_People_ParkingSpaceModel");

            migrationBuilder.AddForeignKey(
                name: "FK_People_ParkingSpaces_ParkingSpaceModel",
                table: "People",
                column: "ParkingSpaceModel",
                principalTable: "ParkingSpaces",
                principalColumn: "ParkingSpaceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
