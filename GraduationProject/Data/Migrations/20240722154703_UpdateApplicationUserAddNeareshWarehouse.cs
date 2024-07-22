using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApplicationUserAddNeareshWarehouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NearestWarehouseId",
                schema: "security",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_NearestWarehouseId",
                schema: "security",
                table: "Users",
                column: "NearestWarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Warehouse_NearestWarehouseId",
                schema: "security",
                table: "Users",
                column: "NearestWarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Warehouse_NearestWarehouseId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_NearestWarehouseId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NearestWarehouseId",
                schema: "security",
                table: "Users");
        }
    }
}
