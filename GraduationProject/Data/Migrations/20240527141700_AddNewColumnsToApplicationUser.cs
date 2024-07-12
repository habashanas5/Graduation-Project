using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    public partial class AddNewColumnsToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "security",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                schema: "security",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "security",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "security",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                schema: "security",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                schema: "security",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

                migrationBuilder.AddColumn<string>(
                    name: "ZipCode",
                    schema: "security",
                    table: "Users",
                    type: "nvarchar(max)",
                    nullable: true);
            

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                schema: "security",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SelectedCompanyId",
                schema: "security",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                schema: "security",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                schema: "security",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                schema: "security",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAtUtc",
                schema: "security",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsNotDeleted",
                schema: "security",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefaultAdmin",
                schema: "security",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnline",
                schema: "security",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                schema: "security",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "FullName", schema: "security", table: "Users");
            migrationBuilder.DropColumn(name: "JobTitle", schema: "security", table: "Users");
            migrationBuilder.DropColumn(name: "Address", schema: "security", table: "Users");
            migrationBuilder.DropColumn(name: "City", schema: "security", table: "Users");
            migrationBuilder.DropColumn(name: "State", schema: "security", table: "Users");
            migrationBuilder.DropColumn(name: "Country", schema: "security", table: "Users");
            migrationBuilder.DropColumn(name: "ZipCode", schema: "security", table: "Users");
            migrationBuilder.DropColumn(name: "Avatar", schema: "security", table: "Users");
            migrationBuilder.DropColumn(name: "SelectedCompanyId", schema: "security", table: "Users");
            migrationBuilder.DropColumn(name: "CreatedByUserId", schema: "security", table: "Users");
            migrationBuilder.DropColumn(name: "CreatedAtUtc", schema: "security", table: "Users");
            migrationBuilder.DropColumn(name: "UpdatedByUserId", schema: "security", table: "Users");
            migrationBuilder.DropColumn(name: "UpdatedAtUtc", schema: "security", table: "Users");
            migrationBuilder.DropColumn(name: "IsNotDeleted", schema: "security", table: "Users");
            migrationBuilder.DropColumn(name: "IsDefaultAdmin", schema: "security", table: "Users");
            migrationBuilder.DropColumn(name: "IsOnline", schema: "security", table: "Users");
            migrationBuilder.DropColumn(name: "UserType", schema: "security", table: "Users");
        }
    }
}
