using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTableFactoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropIndex(
                name: "IX_FactoryContacts_FactoryId",
                table: "FactoryContacts");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "FactoryContacts");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryContacts_FactorysId",
                table: "FactoryContacts",
                column: "FactorysId");

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
         
            migrationBuilder.DropIndex(
                name: "IX_FactoryContacts_FactorysId",
                table: "FactoryContacts");

            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "FactoryContacts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FactoryContacts_FactoryId",
                table: "FactoryContacts",
                column: "FactoryId");

        
        }
    }
}

