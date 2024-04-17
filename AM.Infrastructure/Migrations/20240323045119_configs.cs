using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class configs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Flights_FlightsFlightId",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_passengers_PassenengersPassportNumber",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_planes_PlaneFK",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_planes",
                table: "planes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.RenameTable(
                name: "planes",
                newName: "MyPlanes");

            migrationBuilder.RenameTable(
                name: "FlightPassenger",
                newName: "Reservations");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "MyPlanes",
                newName: "PlaneCapacity");

            migrationBuilder.RenameIndex(
                name: "IX_FlightPassenger_PassenengersPassportNumber",
                table: "Reservations",
                newName: "IX_Reservations_PassenengersPassportNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyPlanes",
                table: "MyPlanes",
                column: "PlaneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                columns: new[] { "FlightsFlightId", "PassenengersPassportNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_MyPlanes_PlaneFK",
                table: "Flights",
                column: "PlaneFK",
                principalTable: "MyPlanes",
                principalColumn: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Flights_FlightsFlightId",
                table: "Reservations",
                column: "FlightsFlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_passengers_PassenengersPassportNumber",
                table: "Reservations",
                column: "PassenengersPassportNumber",
                principalTable: "passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_MyPlanes_PlaneFK",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Flights_FlightsFlightId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_passengers_PassenengersPassportNumber",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyPlanes",
                table: "MyPlanes");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "FlightPassenger");

            migrationBuilder.RenameTable(
                name: "MyPlanes",
                newName: "planes");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_PassenengersPassportNumber",
                table: "FlightPassenger",
                newName: "IX_FlightPassenger_PassenengersPassportNumber");

            migrationBuilder.RenameColumn(
                name: "PlaneCapacity",
                table: "planes",
                newName: "Capacity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "FlightsFlightId", "PassenengersPassportNumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_planes",
                table: "planes",
                column: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Flights_FlightsFlightId",
                table: "FlightPassenger",
                column: "FlightsFlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_passengers_PassenengersPassportNumber",
                table: "FlightPassenger",
                column: "PassenengersPassportNumber",
                principalTable: "passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_planes_PlaneFK",
                table: "Flights",
                column: "PlaneFK",
                principalTable: "planes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
