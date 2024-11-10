using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HanaGuro2.Migrations
{
    /// <inheritdoc />
    public partial class SeedBiomes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Biomes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Grassland" },
                    { 2, "Forest" },
                    { 3, "Mountain" },
                    { 4, "Jungle" },
                    { 5, "Garden" },
                    { 6, "Desert" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Biomes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Biomes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Biomes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Biomes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Biomes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Biomes",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
