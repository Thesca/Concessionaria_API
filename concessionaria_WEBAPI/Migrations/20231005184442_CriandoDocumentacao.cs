using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace concessionaria_WEBAPI.Migrations
{
    /// <inheritdoc />
    public partial class CriandoDocumentacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Placa",
                table: "Garagem",
                newName: "PlacaVaga");

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    PlacaDoc = table.Column<string>(type: "TEXT", nullable: false),
                    CRLV = table.Column<bool>(type: "INTEGER", nullable: false),
                    IPVA = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.PlacaDoc);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.RenameColumn(
                name: "PlacaVaga",
                table: "Garagem",
                newName: "Placa");
        }
    }
}
