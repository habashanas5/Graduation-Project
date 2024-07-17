using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFactoryTypeAndFactoryClassification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factory_VendorCategory_FactoriesClassificationId",
                table: "Factory");

            migrationBuilder.DropForeignKey(
                name: "FK_Factory_VendorGroup_FactoryTypeId",
                table: "Factory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VendorGroup",
                table: "VendorGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VendorCategory",
                table: "VendorCategory");

            migrationBuilder.RenameTable(
                name: "VendorGroup",
                newName: "FactoryType");

            migrationBuilder.RenameTable(
                name: "VendorCategory",
                newName: "FactoryClassification");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FactoryType",
                table: "FactoryType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FactoryClassification",
                table: "FactoryClassification",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Factory_FactoryClassification_FactoriesClassificationId",
                table: "Factory",
                column: "FactoriesClassificationId",
                principalTable: "FactoryClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factory_FactoryType_FactoryTypeId",
                table: "Factory",
                column: "FactoryTypeId",
                principalTable: "FactoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factory_FactoryClassification_FactoriesClassificationId",
                table: "Factory");

            migrationBuilder.DropForeignKey(
                name: "FK_Factory_FactoryType_FactoryTypeId",
                table: "Factory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FactoryType",
                table: "FactoryType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FactoryClassification",
                table: "FactoryClassification");

            migrationBuilder.RenameTable(
                name: "FactoryType",
                newName: "VendorGroup");

            migrationBuilder.RenameTable(
                name: "FactoryClassification",
                newName: "VendorCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendorGroup",
                table: "VendorGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendorCategory",
                table: "VendorCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Factory_VendorCategory_FactoriesClassificationId",
                table: "Factory",
                column: "FactoriesClassificationId",
                principalTable: "VendorCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factory_VendorGroup_FactoryTypeId",
                table: "Factory",
                column: "FactoryTypeId",
                principalTable: "VendorGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
