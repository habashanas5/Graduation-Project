using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnToTheSalesOrderNewss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NearestDeliveryCompanyId",
                table: "SalesOrder",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NearestDeliveryId",
                table: "SalesOrder",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_NearestDeliveryCompanyId",
                table: "SalesOrder",
                column: "NearestDeliveryCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrder_DeliveryCompany_NearestDeliveryCompanyId",
                table: "SalesOrder",
                column: "NearestDeliveryCompanyId",
                principalTable: "DeliveryCompany",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrder_DeliveryCompany_NearestDeliveryCompanyId",
                table: "SalesOrder");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrder_NearestDeliveryCompanyId",
                table: "SalesOrder");

            migrationBuilder.DropColumn(
                name: "NearestDeliveryCompanyId",
                table: "SalesOrder");

            migrationBuilder.DropColumn(
                name: "NearestDeliveryId",
                table: "SalesOrder");
        }
    }
}
