using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateproductReurn1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "SalesReturn",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturn_ApplicationUserId",
                table: "SalesReturn",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturn_Users_ApplicationUserId",
                table: "SalesReturn",
                column: "ApplicationUserId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturn_Users_ApplicationUserId",
                table: "SalesReturn");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturn_ApplicationUserId",
                table: "SalesReturn");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "SalesReturn");
        }
    }
}
