using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateSalesReturn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "SalesReturnProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnProduct_ProductId",
                table: "SalesReturnProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturnProduct_Product_ProductId",
                table: "SalesReturnProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturnProduct_Product_ProductId",
                table: "SalesReturnProduct");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturnProduct_ProductId",
                table: "SalesReturnProduct");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SalesReturnProduct");
        }
    }
}
