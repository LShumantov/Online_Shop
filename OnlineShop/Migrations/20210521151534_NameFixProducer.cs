using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Migrations
{
    public partial class NameFixManufacture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Prducers_ManufactureId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prducers",
                table: "Prducers");

            migrationBuilder.RenameTable(
                name: "Prducers",
                newName: "Manufactures");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufactures",
                table: "Manufactures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Manufactures_ManufactureId",
                table: "Products",
                column: "ManufactureId",
                principalTable: "Manufactures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Manufactures_ManufactureId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufactures",
                table: "Manufactures");

            migrationBuilder.RenameTable(
                name: "Manufactures",
                newName: "Prducers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prducers",
                table: "Prducers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Prducers_ManufactureId",
                table: "Products",
                column: "ManufactureId",
                principalTable: "Prducers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
