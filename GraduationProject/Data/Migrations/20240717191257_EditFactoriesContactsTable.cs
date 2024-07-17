using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditFactoriesContactsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryContacts_Factorys_FactorysId",
                table: "FactoryContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Factorys_FactoryClassification_VendorCategoryId",
                table: "Factorys");

            migrationBuilder.DropForeignKey(
                name: "FK_Factorys_FactoryType_VendorGroupId",
                table: "Factorys");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_Factorys_VendorId",
                table: "PurchaseOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factorys",
                table: "Factorys");

            migrationBuilder.RenameTable(
                name: "Factorys",
                newName: "Factory");

            migrationBuilder.RenameColumn(
                name: "FactorysId",
                table: "FactoryContacts",
                newName: "VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_FactoryContacts_FactorysId",
                table: "FactoryContacts",
                newName: "IX_FactoryContacts_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_Factorys_VendorGroupId",
                table: "Factory",
                newName: "IX_Factory_VendorGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Factorys_VendorCategoryId",
                table: "Factory",
                newName: "IX_Factory_VendorCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factory",
                table: "Factory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Factory_FactoryClassification_VendorCategoryId",
                table: "Factory",
                column: "VendorCategoryId",
                principalTable: "FactoryClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factory_FactoryType_VendorGroupId",
                table: "Factory",
                column: "VendorGroupId",
                principalTable: "FactoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryContacts_Factory_VendorId",
                table: "FactoryContacts",
                column: "VendorId",
                principalTable: "Factory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrder_Factory_VendorId",
                table: "PurchaseOrder",
                column: "VendorId",
                principalTable: "Factory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factory_FactoryClassification_VendorCategoryId",
                table: "Factory");

            migrationBuilder.DropForeignKey(
                name: "FK_Factory_FactoryType_VendorGroupId",
                table: "Factory");

            migrationBuilder.DropForeignKey(
                name: "FK_FactoryContacts_Factory_VendorId",
                table: "FactoryContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_Factory_VendorId",
                table: "PurchaseOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factory",
                table: "Factory");

            migrationBuilder.RenameTable(
                name: "Factory",
                newName: "Factorys");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                table: "FactoryContacts",
                newName: "FactorysId");

            migrationBuilder.RenameIndex(
                name: "IX_FactoryContacts_VendorId",
                table: "FactoryContacts",
                newName: "IX_FactoryContacts_FactorysId");

            migrationBuilder.RenameIndex(
                name: "IX_Factory_VendorGroupId",
                table: "Factorys",
                newName: "IX_Factorys_VendorGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Factory_VendorCategoryId",
                table: "Factorys",
                newName: "IX_Factorys_VendorCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factorys",
                table: "Factorys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryContacts_Factorys_FactorysId",
                table: "FactoryContacts",
                column: "FactorysId",
                principalTable: "Factorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factorys_FactoryClassification_VendorCategoryId",
                table: "Factorys",
                column: "VendorCategoryId",
                principalTable: "FactoryClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factorys_FactoryType_VendorGroupId",
                table: "Factorys",
                column: "VendorGroupId",
                principalTable: "FactoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrder_Factorys_VendorId",
                table: "PurchaseOrder",
                column: "VendorId",
                principalTable: "Factorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
