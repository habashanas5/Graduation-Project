using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class newCustomerUserr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerCategoryId",
                schema: "security",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerCategoryIdUser",
                schema: "security",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerGroupId",
                schema: "security",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerGroupIdUser",
                schema: "security",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CustomerCategoryId",
                schema: "security",
                table: "Users",
                column: "CustomerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CustomerGroupId",
                schema: "security",
                table: "Users",
                column: "CustomerGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CustomerCategory_CustomerCategoryId",
                schema: "security",
                table: "Users",
                column: "CustomerCategoryId",
                principalTable: "CustomerCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CustomerGroup_CustomerGroupId",
                schema: "security",
                table: "Users",
                column: "CustomerGroupId",
                principalTable: "CustomerGroup",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CustomerCategory_CustomerCategoryId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_CustomerGroup_CustomerGroupId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CustomerCategoryId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CustomerGroupId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CustomerCategoryId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CustomerCategoryIdUser",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CustomerGroupId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CustomerGroupIdUser",
                schema: "security",
                table: "Users");
        }
    }
}
