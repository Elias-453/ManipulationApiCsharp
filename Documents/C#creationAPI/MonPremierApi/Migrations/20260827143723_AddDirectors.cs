using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MonPremierApi.Migrations
{
    /// <inheritdoc />
    public partial class AddDirectors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Age", "Nom", "nationalite" },
                values: new object[,]
                {
                    { 1, 56, "Christopher Nolan", "Britannique" },
                    { 2, 63, "Quentin Tarantino", "Américaine" },
                    { 3, 55, "Sofia Coppola", "Américaine" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
