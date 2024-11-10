using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HanaGuro2.Migrations
{
    /// <inheritdoc />
    public partial class SeedPlantTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PlantTypes",
                columns: new[] { "Id", "ImageKey", "Name" },
                values: new object[,]
                {
                    { 1, "Chlorophytum", "Chlorophytum" },
                    { 2, "Echeveria", "Echeveria" },
                    { 3, "Ficus", "Ficus" },
                    { 4, "Monstera", "Monstera" },
                    { 5, "Saintpaula", "Saintpaulia" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
