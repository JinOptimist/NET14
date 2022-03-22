using Microsoft.EntityFrameworkCore.Migrations;

namespace Net14.Web.Migrations
{
    public partial class DefValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserPhoto",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "/images/Social/User.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "/wwwroot/images/Social/User.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserPhoto",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "/wwwroot/images/Social/User.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "/images/Social/User.jpg");
        }
    }
}
