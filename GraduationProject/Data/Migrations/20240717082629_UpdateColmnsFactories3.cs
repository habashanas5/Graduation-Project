using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColmnsFactories3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factory_FactoryClassification_FactoryClassificationId",
                table: "Factory");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryClassificationId",
                table: "Factory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FactoryClassificationsId",
                table: "Factory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Factory_FactoryClassification_FactoryClassificationId",
                table: "Factory",
                column: "FactoryClassificationId",
                principalTable: "FactoryClassification",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factory_FactoryClassification_FactoryClassificationId",
                table: "Factory");

            migrationBuilder.DropColumn(
                name: "FactoryClassificationsId",
                table: "Factory");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryClassificationId",
                table: "Factory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Factory_FactoryClassification_FactoryClassificationId",
                table: "Factory",
                column: "FactoryClassificationId",
                principalTable: "FactoryClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
