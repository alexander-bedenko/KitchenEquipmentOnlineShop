using Microsoft.EntityFrameworkCore.Migrations;

namespace KitchenEquipmentOnlineShop.DataAccess.Migrations
{
    public partial class addedbowldepth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "BowlDepth",
                table: "Sinks",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BowlDepth",
                table: "Sinks");
        }
    }
}
