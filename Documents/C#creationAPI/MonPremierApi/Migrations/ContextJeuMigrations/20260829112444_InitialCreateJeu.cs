using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonPremierApi.Migrations.ContextJeuMigrations
{
    /// <inheritdoc />
    public partial class InitialCreateJeu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    OriginePays = table.Column<string>(type: "TEXT", nullable: false),
                    CreationStudio = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jeux",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titre = table.Column<string>(type: "TEXT", nullable: false),
                    StudioId = table.Column<int>(type: "INTEGER", nullable: false),
                    DatePublication = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jeux", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jeux_Studios_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jeux_StudioId",
                table: "Jeux",
                column: "StudioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jeux");

            migrationBuilder.DropTable(
                name: "Studios");
        }
    }
}
