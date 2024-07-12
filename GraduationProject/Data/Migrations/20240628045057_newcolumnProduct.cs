using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class newcolumnProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageFileName",
                table: "Product",
                newName: "MetaKeyWords");

            migrationBuilder.RenameColumn(
                name: "ImageData",
                table: "Product",
                newName: "ImageData2");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData1",
                table: "Product",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName1",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName2",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "oldPrice",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImageFileName1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImageFileName2",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "oldPrice",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "MetaKeyWords",
                table: "Product",
                newName: "ImageFileName");

            migrationBuilder.RenameColumn(
                name: "ImageData2",
                table: "Product",
                newName: "ImageData");
        }
    }
}
