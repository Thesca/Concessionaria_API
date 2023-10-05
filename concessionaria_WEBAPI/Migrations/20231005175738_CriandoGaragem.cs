using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace concessionaria_WEBAPI.Migrations
{
    /// <inheritdoc />
    public partial class CriandoGaragem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "diaDaLocacao",
                table: "Mensalista",
                newName: "DiaDaLocacao");

            migrationBuilder.CreateTable(
                name: "Garagem",
                columns: table => new
                {
                    IdVaga = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Placa = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garagem", x => x.IdVaga);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Garagem");

            migrationBuilder.RenameColumn(
                name: "DiaDaLocacao",
                table: "Mensalista",
                newName: "diaDaLocacao");
        }
    }
}
