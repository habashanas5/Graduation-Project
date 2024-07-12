using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    IsNotDeleted = table.Column<bool>(nullable: false),
                    RowGuid = table.Column<Guid>(nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(nullable: true),
                    UpdatedByUserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false, maxLength: 100),
                    Currency = table.Column<string>(nullable: false, maxLength: 50),
                    TimeZone = table.Column<string>(nullable: false, maxLength: 50),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Street = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    State = table.Column<string>(maxLength: 100, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    FaxNumber = table.Column<string>(maxLength: 20, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 100, nullable: true),
                    Website = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
