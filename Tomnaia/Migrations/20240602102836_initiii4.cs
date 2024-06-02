using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tomnaia.Migrations
{
    /// <inheritdoc />
    public partial class initiii4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_ReceiverId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_ReceiverId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Notifications");

            migrationBuilder.AddColumn<string>(
                name: "DriverId",
                table: "Notifications",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassengerId",
                table: "Notifications",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_DriverId",
                table: "Notifications",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_PassengerId",
                table: "Notifications",
                column: "PassengerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Drivers_DriverId",
                table: "Notifications",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Passengers_PassengerId",
                table: "Notifications",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Drivers_DriverId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Passengers_PassengerId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_DriverId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_PassengerId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PassengerId",
                table: "Notifications");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "Notifications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReceiverId",
                table: "Notifications",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_ReceiverId",
                table: "Notifications",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
