using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class editSalesOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "SalesOrder",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_UserId",
                table: "SalesOrder",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrder_Users_UserId",
                table: "SalesOrder",
                column: "UserId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrder_Users_UserId",
                table: "SalesOrder");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrder_UserId",
                table: "SalesOrder");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SalesOrder");
        }
    }
}
