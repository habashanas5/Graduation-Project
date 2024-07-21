using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          //   migrationBuilder.Sql("INSERT INTO [security].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [Avatar]) VALUES (N'30050345-9664-4b16-ab73-c45ef1e2ac9a', N'habashanas5', N'HABASHANAS5', N'habashanas716@gmail.com', N'HABASHANAS716@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEML8YHd1sMk+6U234xoeW5IRMwXudWdlabSWC9wTfm6tORVEyYc1RpDQMaXTGeIA5Q==', N'AWQPX3OMIAKTPWJ4SZSAWEXCZT7H2WF4', N'68fa800a-6fc0-4ea9-a529-ec27b4838a1e', NULL, 0, 0, NULL, 1, 0, N'Anas Habash', NULL)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           //   migrationBuilder.Sql("DELETE FROM [security].[Users] WHERE Id = '30050345-9664-4b16-ab73-c45ef1e2ac9a'");

        }
    }
}
