using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update4ColoumnInApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Longitude",
                schema: "security",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "CityInfoId",
                schema: "security",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityInfoId",
                schema: "security",
                table: "Users",
                column: "CityInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CityInfo_CityInfoId",
                schema: "security",
                table: "Users",
                column: "CityInfoId",
                principalTable: "CityInfo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CityInfo_CityInfoId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CityInfoId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CityInfoId",
                schema: "security",
                table: "Users");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                schema: "security",
                table: "Users",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                schema: "security",
                table: "Users",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
