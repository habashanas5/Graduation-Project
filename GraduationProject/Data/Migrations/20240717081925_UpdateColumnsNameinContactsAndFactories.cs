using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnsNameinContactsAndFactories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factory_FactoryClassification_FactoriesClassificationId",
                table: "Factory");

            migrationBuilder.DropForeignKey(
                name: "FK_FactoryContacts_Factory_FactoryId",
                table: "FactoryContacts");

            migrationBuilder.RenameColumn(
                name: "FactoriesClassificationId",
                table: "Factory",
                newName: "FactoryClassificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Factory_FactoriesClassificationId",
                table: "Factory",
                newName: "IX_Factory_FactoryClassificationId");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "FactoryContacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FactorysId",
                table: "FactoryContacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Factory_FactoryClassification_FactoryClassificationId",
                table: "Factory",
                column: "FactoryClassificationId",
                principalTable: "FactoryClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryContacts_Factory_FactoryId",
                table: "FactoryContacts",
                column: "FactoryId",
                principalTable: "Factory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factory_FactoryClassification_FactoryClassificationId",
                table: "Factory");

            migrationBuilder.DropForeignKey(
                name: "FK_FactoryContacts_Factory_FactoryId",
                table: "FactoryContacts");

            migrationBuilder.DropColumn(
                name: "FactorysId",
                table: "FactoryContacts");

            migrationBuilder.RenameColumn(
                name: "FactoryClassificationId",
                table: "Factory",
                newName: "FactoriesClassificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Factory_FactoryClassificationId",
                table: "Factory",
                newName: "IX_Factory_FactoriesClassificationId");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryId",
                table: "FactoryContacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Factory_FactoryClassification_FactoriesClassificationId",
                table: "Factory",
                column: "FactoriesClassificationId",
                principalTable: "FactoryClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryContacts_Factory_FactoryId",
                table: "FactoryContacts",
                column: "FactoryId",
                principalTable: "Factory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
