using Microsoft.EntityFrameworkCore.Migrations;

namespace Parking_Lot_Reservation.Migrations
{
    public partial class PerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpaces_People_PersonId",
                table: "ParkingSpaces");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "ParkingSpaces",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpaces_People_PersonId",
                table: "ParkingSpaces",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpaces_People_PersonId",
                table: "ParkingSpaces");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "ParkingSpaces",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpaces_People_PersonId",
                table: "ParkingSpaces",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
