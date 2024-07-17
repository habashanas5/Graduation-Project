using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColmnsFactories2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factory_FactoryType_FactoryTypeId",
                table: "Factory");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryTypeId",
                table: "Factory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FactorysTypeId",
                table: "Factory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Factory_FactoryType_FactoryTypeId",
                table: "Factory",
                column: "FactoryTypeId",
                principalTable: "FactoryType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factory_FactoryType_FactoryTypeId",
                table: "Factory");

            migrationBuilder.DropColumn(
                name: "FactorysTypeId",
                table: "Factory");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryTypeId",
                table: "Factory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Factory_FactoryType_FactoryTypeId",
                table: "Factory",
                column: "FactoryTypeId",
                principalTable: "FactoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
