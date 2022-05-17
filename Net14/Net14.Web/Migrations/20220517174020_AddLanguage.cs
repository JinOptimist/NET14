using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;

namespace Net14.Web.Migrations
{
    public partial class AddLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: Language.Rus);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Users");
        }
    }
}
