using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class AssignAdminUserToAllRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          //  migrationBuilder.Sql("insert into[security].[UserRoles] (UserId, RoleId) select 'a4d907f7-643d-4d4f-bf30-285bcc8ccc45', Id From[security].[Roles]") ;
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          //  migrationBuilder.Sql("DELETE FROM [security].[UserRoles] WHERE UserId = 'a4d907f7-643d-4d4f-bf30-285bcc8ccc45'");
        }
    }
}
