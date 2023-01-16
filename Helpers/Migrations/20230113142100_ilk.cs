using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FutbolDunyasi.Migrations
{
    /// <inheritdoc />
    public partial class ilk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Takimlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Takimlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oyuncular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FormaNo = table.Column<int>(type: "int", nullable: false),
                    Mevki = table.Column<int>(type: "int", nullable: false),
                    TakimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oyuncular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oyuncular_Takimlar_TakimId",
                        column: x => x.TakimId,
                        principalTable: "Takimlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Takimlar",
                columns: new[] { "Id", "Ad" },
                values: new object[,]
                {
                    { 1, "Fenerbahçe" },
                    { 2, "Galatasaray" }
                });

            migrationBuilder.InsertData(
                table: "Oyuncular",
                columns: new[] { "Id", "Ad", "FormaNo", "Mevki", "TakimId" },
                values: new object[,]
                {
                    { 1, "Altay Bayındır", 1, 1, 1 },
                    { 2, "Serdar Dursun", 19, 4, 1 },
                    { 3, "Fernando Muslera", 1, 1, 2 },
                    { 4, "Haris Seferovic", 9, 4, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oyuncular_TakimId",
                table: "Oyuncular",
                column: "TakimId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oyuncular");

            migrationBuilder.DropTable(
                name: "Takimlar");
        }
    }
}
