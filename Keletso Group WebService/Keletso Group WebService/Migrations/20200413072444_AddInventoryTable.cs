using Microsoft.EntityFrameworkCore.Migrations;

namespace Keletso_Group_WebService.Migrations
{
    public partial class AddInventoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Units = table.Column<int>(nullable: false),
                    NumberSoldUnits = table.Column<int>(nullable: false),
                    RemainingUnits = table.Column<int>(nullable: false),
                    TotalCostPrice = table.Column<double>(nullable: false),
                    TotalSellingPrice = table.Column<double>(nullable: false),
                    Profit = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");
        }
    }
}
