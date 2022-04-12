using Microsoft.EntityFrameworkCore.Migrations;

namespace Net14.Web.Migrations
{
    public partial class ReNameStoreImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "StoreImages",
                newName: "Url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "StoreImages",
                newName: "Name");
        }
    }
}
