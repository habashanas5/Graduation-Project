using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSalesOrderItemToHaveNearestWarehouseId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WarehouseNumber",
                table: "SalesOrderItem");

            migrationBuilder.AddColumn<int>(
                name: "NearestWarehouseId",
                table: "SalesOrderItem",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NearestWarehouseId",
                table: "SalesOrderItem");

            migrationBuilder.AddColumn<int>(
                name: "WarehouseNumber",
                table: "SalesOrderItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
