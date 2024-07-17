using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVendorContactTableToTheFactoryContactsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendorContact_Factory_VendorId",
                table: "VendorContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VendorContact",
                table: "VendorContact");

            migrationBuilder.RenameTable(
                name: "VendorContact",
                newName: "FactoryContacts");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                table: "FactoryContacts",
                newName: "FactoryId");

            migrationBuilder.RenameIndex(
                name: "IX_VendorContact_VendorId",
                table: "FactoryContacts",
                newName: "IX_FactoryContacts_FactoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FactoryContacts",
                table: "FactoryContacts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryContacts_Factory_FactoryId",
                table: "FactoryContacts",
                column: "FactoryId",
                principalTable: "Factory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryContacts_Factory_FactoryId",
                table: "FactoryContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FactoryContacts",
                table: "FactoryContacts");

            migrationBuilder.RenameTable(
                name: "FactoryContacts",
                newName: "VendorContact");

            migrationBuilder.RenameColumn(
                name: "FactoryId",
                table: "VendorContact",
                newName: "VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_FactoryContacts_FactoryId",
                table: "VendorContact",
                newName: "IX_VendorContact_VendorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendorContact",
                table: "VendorContact",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VendorContact_Factory_VendorId",
                table: "VendorContact",
                column: "VendorId",
                principalTable: "Factory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
