using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantSearchApi.Migrations
{
    public partial class RestaurantUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1,
                column: "Budget",
                value: 1000m);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 2,
                column: "Budget",
                value: 600m);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 3,
                column: "Budget",
                value: 800m);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 4,
                column: "Budget",
                value: 1200m);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 5,
                column: "Budget",
                value: 1500m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1,
                column: "Budget",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 2,
                column: "Budget",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 3,
                column: "Budget",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 4,
                column: "Budget",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 5,
                column: "Budget",
                value: 0m);
        }
    }
}
