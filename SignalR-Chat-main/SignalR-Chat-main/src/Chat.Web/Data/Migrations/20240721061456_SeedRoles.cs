﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Chat.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
          table: "Roles",
          columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
          values: new object[] { Guid.NewGuid().ToString(), "Customer", "Customer".ToUpper(), Guid.NewGuid().ToString() },
          schema: "security"
        );
            migrationBuilder.InsertData(
            table: "Roles",
            columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
            values: new object[] { Guid.NewGuid().ToString(), "Admin", "Admin".ToUpper(), Guid.NewGuid().ToString() },
            schema: "security"
        );

            migrationBuilder.InsertData(
           table: "Roles",
           columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
           values: new object[] { Guid.NewGuid().ToString(), "WarehouseManager", "WarehouseManager".ToUpper(), Guid.NewGuid().ToString() },
           schema: "security"
       );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[Roles]");
        }
    }
}
