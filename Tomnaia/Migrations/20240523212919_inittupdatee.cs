using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tomnaia.Migrations
{
    /// <inheritdoc />
    public partial class inittupdatee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_ReceiverId",
                table: "Notifications");

            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RateValue = table.Column<double>(type: "float", nullable: false),
                    RaterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RatedId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rate_AspNetUsers_RatedId",
                        column: x => x.RatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rate_AspNetUsers_RaterId",
                        column: x => x.RaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rate_RatedId",
                table: "Rate",
                column: "RatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_RaterId",
                table: "Rate",
                column: "RaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_ReceiverId",
                table: "Notifications",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_ReceiverId",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
