using Microsoft.EntityFrameworkCore.Migrations;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;

namespace Net14.Web.Migrations
{
    public partial class AddRoleForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: SiteRole.User);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
