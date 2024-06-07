using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tomnaia.Migrations
{
    /// <inheritdoc />
    public partial class rideOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RideOffers",
                columns: table => new
                {
                    RideOfferId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DriverId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RideRequestId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideOffers", x => x.RideOfferId);
                    table.ForeignKey(
                        name: "FK_RideOffers_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RideOffers_Rides_RideRequestId",
                        column: x => x.RideRequestId,
                        principalTable: "Rides",
                        principalColumn: "RideId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RideOffers_DriverId",
                table: "RideOffers",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RideOffers_RideRequestId",
                table: "RideOffers",
                column: "RideRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RideOffers");
        }
    }
}
