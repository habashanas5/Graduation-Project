using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class addnewColomnsToTheDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SystemWarehouse",
                table: "Warehouse",
                newName: "IsDefault");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Warehouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Warehouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Warehouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Warehouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ranking",
                table: "Vendor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Product",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "rating",
                table: "Product",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "Ranking",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "IsDefault",
                table: "Warehouse",
                newName: "SystemWarehouse");
        }
    }
}
