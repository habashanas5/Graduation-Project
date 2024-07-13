using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class addDeleiveryCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryCompanyId",
                table: "DeliveryOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DeliveryCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsNotDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryCompany", x => x.Id);
                });

            // Insert default DeliveryCompany
            migrationBuilder.Sql("INSERT INTO DeliveryCompany (Name, RowGuid, IsNotDeleted) VALUES ('Default Company', NEWID(), 1)");

            // Get the Id of the inserted default DeliveryCompany
            migrationBuilder.Sql("UPDATE DeliveryOrder SET DeliveryCompanyId = (SELECT TOP 1 Id FROM DeliveryCompany)");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrder_DeliveryCompanyId",
                table: "DeliveryOrder",
                column: "DeliveryCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrder_DeliveryCompany_DeliveryCompanyId",
                table: "DeliveryOrder",
                column: "DeliveryCompanyId",
                principalTable: "DeliveryCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryOrder_DeliveryCompany_DeliveryCompanyId",
                table: "DeliveryOrder");

            migrationBuilder.DropTable(
                name: "DeliveryCompany");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryOrder_DeliveryCompanyId",
                table: "DeliveryOrder");

            migrationBuilder.DropColumn(
                name: "DeliveryCompanyId",
                table: "DeliveryOrder");
        }
    }
}
