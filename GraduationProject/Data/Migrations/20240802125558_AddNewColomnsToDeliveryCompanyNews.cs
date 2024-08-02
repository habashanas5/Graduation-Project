using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColomnsToDeliveryCompanyNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "DeliveryCompany",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "DeliveryCompany",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Lat",
                table: "DeliveryCompany",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Lng",
                table: "DeliveryCompany",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "DeliveryCompany");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "DeliveryCompany");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "DeliveryCompany");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "DeliveryCompany");
        }
    }
}
