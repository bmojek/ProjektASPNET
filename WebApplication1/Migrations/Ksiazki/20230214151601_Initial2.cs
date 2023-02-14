using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations.Ksiazki
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recenzje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KsiazkiRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recenzje_Ksiazki_KsiazkiRefId",
                        column: x => x.KsiazkiRefId,
                        principalTable: "Ksiazki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recenzje_KsiazkiRefId",
                table: "Recenzje",
                column: "KsiazkiRefId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recenzje");
        }
    }
}
