using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class insertTransTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransferProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferOutId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RowGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsNotDeleted = table.Column<bool>(type: "bit", nullable: false)
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

            // إذا كان الجدول WarehouseProduct موجود بالفعل، لا تقم بإنشائه
            // migrationBuilder.CreateTable(
            //     name: "WarehouseProduct",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         WarehouseId = table.Column<int>(type: "int", nullable: false),
            //         ProductId = table.Column<int>(type: "int", nullable: false),
            //         Quantity = table.Column<int>(type: "int", nullable: false),
            //         RowGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //         CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
            //         UpdatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
            //         IsNotDeleted = table.Column<bool>(type: "bit", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_WarehouseProduct", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_WarehouseProduct_Product_ProductId",
            //             column: x => x.ProductId,
            //             principalTable: "Product",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_WarehouseProduct_Warehouse_WarehouseId",
            //             column: x => x.WarehouseId,
            //             principalTable: "Warehouse",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });

            migrationBuilder.CreateIndex(
                name: "IX_TransferProduct_ProductId",
                table: "TransferProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferProduct_TransferOutId",
                table: "TransferProduct",
                column: "TransferOutId");

            // إذا كان الجدول WarehouseProduct موجود بالفعل، لا تقم بإنشاء الفهارس
            // migrationBuilder.CreateIndex(
            //     name: "IX_WarehouseProduct_ProductId",
            //     table: "WarehouseProduct",
            //     column: "ProductId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_WarehouseProduct_WarehouseId",
            //     table: "WarehouseProduct",
            //     column: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransferProduct");

            // لا تقم بحذف الجدول WarehouseProduct
            // migrationBuilder.DropTable(
            //     name: "WarehouseProduct");
        }
    }
}
