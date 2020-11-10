using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantSearchApi.Migrations
{
    public partial class RestaurantSearchApiDataRestaurantContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    RestaurantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Distance = table.Column<int>(nullable: false),
                    Cuisine = table.Column<string>(nullable: true),
                    Budget = table.Column<decimal>(nullable: false),
                    Ratings = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.RestaurantId);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Chicken Biryani", 250m, 1 },
                    { 2, "Chicken Korma", 200m, 2 },
                    { 3, "Shahi Paneer", 250m, 3 },
                    { 4, "Tandoori Roti", 250m, 1 },
                    { 5, "Choley Bhaturey", 100m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Budget", "Cuisine", "Distance", "Location", "Name", "Ratings" },
                values: new object[,]
                {
                    { 1, 0m, "Indian", 20, "JP Nagar, Bangalore 560006", "Barbequnation", (short)5 },
                    { 2, 0m, "Indian", 5, "Koramangala", "Paradize", (short)4 },
                    { 3, 0m, "Italian", 12, "Brigade Road", "Thirteenth floor", (short)2 },
                    { 4, 0m, "Caribbean", 18, "JP Nagar, Bangalore 560009", "Mango Tree", (short)4 },
                    { 5, 0m, "German", 25, "JP Nagar, Bangalore 564555", "Brewsky", (short)5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
