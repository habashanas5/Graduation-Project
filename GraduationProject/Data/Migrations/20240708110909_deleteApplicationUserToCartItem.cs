using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class deleteApplicationUserToCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Users_ApplicationUserId",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_ApplicationUserId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "CartItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "CartItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ApplicationUserId",
                table: "CartItem",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Users_ApplicationUserId",
                table: "CartItem",
                column: "ApplicationUserId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
