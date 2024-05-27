using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tomnaia.Migrations
{
    /// <inheritdoc />
    public partial class addrete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rate_AspNetUsers_RatedId",
                table: "Rate");

            migrationBuilder.DropForeignKey(
                name: "FK_Rate_AspNetUsers_RaterId",
                table: "Rate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rate",
                table: "Rate");

            migrationBuilder.RenameTable(
                name: "Rate",
                newName: "Rates");

            migrationBuilder.RenameIndex(
                name: "IX_Rate_RaterId",
                table: "Rates",
                newName: "IX_Rates_RaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Rate_RatedId",
                table: "Rates",
                newName: "IX_Rates_RatedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rates",
                table: "Rates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_AspNetUsers_RatedId",
                table: "Rates",
                column: "RatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_AspNetUsers_RaterId",
                table: "Rates",
                column: "RaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_AspNetUsers_RatedId",
                table: "Rates");

            migrationBuilder.DropForeignKey(
                name: "FK_Rates_AspNetUsers_RaterId",
                table: "Rates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rates",
                table: "Rates");

            migrationBuilder.RenameTable(
                name: "Rates",
                newName: "Rate");

            migrationBuilder.RenameIndex(
                name: "IX_Rates_RaterId",
                table: "Rate",
                newName: "IX_Rate_RaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Rates_RatedId",
                table: "Rate",
                newName: "IX_Rate_RatedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rate",
                table: "Rate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rate_AspNetUsers_RatedId",
                table: "Rate",
                column: "RatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rate_AspNetUsers_RaterId",
                table: "Rate",
                column: "RaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
