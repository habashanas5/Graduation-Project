using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class deleteTransTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransferProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransferProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TransferOutId = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNotDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RowGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferProduct_TransferOut_TransferOutId",
                        column: x => x.TransferOutId,
                        principalTable: "TransferOut",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransferProduct_ProductId",
                table: "TransferProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferProduct_TransferOutId",
                table: "TransferProduct",
                column: "TransferOutId");
        }
    }
}
