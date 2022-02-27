using Microsoft.EntityFrameworkCore.Migrations;

namespace Parking_Lot_Reservation.Migrations
{
    public partial class TablesConnected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_ParkingSpaces_ParkingSpaceId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_ParkingSpaceId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ParkingSpaceId",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "ParkingSpaces",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpaces_PersonId",
                table: "ParkingSpaces",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpaces_People_PersonId",
                table: "ParkingSpaces",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpaces_People_PersonId",
                table: "ParkingSpaces");

            migrationBuilder.DropIndex(
                name: "IX_ParkingSpaces_PersonId",
                table: "ParkingSpaces");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "ParkingSpaces");

            migrationBuilder.AddColumn<int>(
                name: "ParkingSpaceId",
                table: "People",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_ParkingSpaceId",
                table: "People",
                column: "ParkingSpaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_ParkingSpaces_ParkingSpaceId",
                table: "People",
                column: "ParkingSpaceId",
                principalTable: "ParkingSpaces",
                principalColumn: "ParkingSpaceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
