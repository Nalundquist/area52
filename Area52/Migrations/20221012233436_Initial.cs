using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Area52.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aliens",
                columns: table => new
                {
                    AlienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AlienName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliens", x => x.AlienId);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    PlanetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlanetName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Atmosphere = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.PlanetId);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    SpeciiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpeciiName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.SpeciiId);
                });

            migrationBuilder.CreateTable(
                name: "AlienPlanet",
                columns: table => new
                {
                    AlienPlanetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AlienId = table.Column<int>(type: "int", nullable: false),
                    PlanetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlienPlanet", x => x.AlienPlanetId);
                    table.ForeignKey(
                        name: "FK_AlienPlanet_Aliens_AlienId",
                        column: x => x.AlienId,
                        principalTable: "Aliens",
                        principalColumn: "AlienId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlienPlanet_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "PlanetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlienSpecii",
                columns: table => new
                {
                    AlienSpeciiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AlienId = table.Column<int>(type: "int", nullable: false),
                    SpeciiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlienSpecii", x => x.AlienSpeciiId);
                    table.ForeignKey(
                        name: "FK_AlienSpecii_Aliens_AlienId",
                        column: x => x.AlienId,
                        principalTable: "Aliens",
                        principalColumn: "AlienId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlienSpecii_Species_SpeciiId",
                        column: x => x.SpeciiId,
                        principalTable: "Species",
                        principalColumn: "SpeciiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanetSpecii",
                columns: table => new
                {
                    PlanetSpeciiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpeciiId = table.Column<int>(type: "int", nullable: false),
                    PlanetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanetSpecii", x => x.PlanetSpeciiId);
                    table.ForeignKey(
                        name: "FK_PlanetSpecii_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "PlanetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanetSpecii_Species_SpeciiId",
                        column: x => x.SpeciiId,
                        principalTable: "Species",
                        principalColumn: "SpeciiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlienPlanet_AlienId",
                table: "AlienPlanet",
                column: "AlienId");

            migrationBuilder.CreateIndex(
                name: "IX_AlienPlanet_PlanetId",
                table: "AlienPlanet",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_AlienSpecii_AlienId",
                table: "AlienSpecii",
                column: "AlienId");

            migrationBuilder.CreateIndex(
                name: "IX_AlienSpecii_SpeciiId",
                table: "AlienSpecii",
                column: "SpeciiId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanetSpecii_PlanetId",
                table: "PlanetSpecii",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanetSpecii_SpeciiId",
                table: "PlanetSpecii",
                column: "SpeciiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlienPlanet");

            migrationBuilder.DropTable(
                name: "AlienSpecii");

            migrationBuilder.DropTable(
                name: "PlanetSpecii");

            migrationBuilder.DropTable(
                name: "Aliens");

            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
