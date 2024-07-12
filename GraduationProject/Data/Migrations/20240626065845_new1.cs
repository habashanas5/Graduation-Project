using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class new1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "ProductGroup");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "ProductGroup",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "ProductGroup");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "ProductGroup",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
