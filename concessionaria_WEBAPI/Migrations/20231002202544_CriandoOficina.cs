using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace concessionaria_WEBAPI.Migrations
{
    /// <inheritdoc />
    public partial class CriandoOficina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oficina",
                columns: table => new
                {
                    IdCarroOficina = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Procedimento = table.Column<string>(type: "TEXT", maxLength: 511, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oficina", x => x.IdCarroOficina);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oficina");
        }
    }
}
