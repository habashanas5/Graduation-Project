using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateproductReurn2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturn_Users_ApplicationUserId",
                table: "SalesReturn");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "SalesReturn",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesReturn_ApplicationUserId",
                table: "SalesReturn",
                newName: "IX_SalesReturn_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturn_Users_UserId",
                table: "SalesReturn",
                column: "UserId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturn_Users_UserId",
                table: "SalesReturn");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SalesReturn",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesReturn_UserId",
                table: "SalesReturn",
                newName: "IX_SalesReturn_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturn_Users_ApplicationUserId",
                table: "SalesReturn",
                column: "ApplicationUserId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
