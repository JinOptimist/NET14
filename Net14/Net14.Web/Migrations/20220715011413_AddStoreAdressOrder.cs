using Microsoft.EntityFrameworkCore.Migrations;

namespace Net14.Web.Migrations
{
    public partial class AddStoreAdressOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryOrPickup",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoreAddressId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StoreAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    House = table.Column<int>(type: "int", nullable: false),
                    Room = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreAddress", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreAddressId",
                table: "Orders",
                column: "StoreAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_StoreAddress_StoreAddressId",
                table: "Orders",
                column: "StoreAddressId",
                principalTable: "StoreAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_StoreAddress_StoreAddressId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "StoreAddress");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StoreAddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryOrPickup",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StoreAddressId",
                table: "Orders");
        }
    }
}
