using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditTableSalesOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "SalesOrderItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseNumber",
                table: "SalesOrderItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderItem_WarehouseId",
                table: "SalesOrderItem",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderItem_Warehouse_WarehouseId",
                table: "SalesOrderItem",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderItem_Warehouse_WarehouseId",
                table: "SalesOrderItem");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrderItem_WarehouseId",
                table: "SalesOrderItem");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "SalesOrderItem");

            migrationBuilder.DropColumn(
                name: "WarehouseNumber",
                table: "SalesOrderItem");
        }
    }
}
