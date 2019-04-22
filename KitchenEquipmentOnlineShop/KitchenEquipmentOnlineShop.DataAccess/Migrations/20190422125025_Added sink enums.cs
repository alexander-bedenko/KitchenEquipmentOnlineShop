using Microsoft.EntityFrameworkCore.Migrations;

namespace KitchenEquipmentOnlineShop.DataAccess.Migrations
{
    public partial class Addedsinkenums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "Form",
                table: "Sinks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Material",
                table: "Sinks",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Form",
                table: "Sinks");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "Sinks");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Companies",
                nullable: true);
        }
    }
}
