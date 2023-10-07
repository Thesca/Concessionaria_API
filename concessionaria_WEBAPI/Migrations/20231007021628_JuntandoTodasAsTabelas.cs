using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concessionaria.cs.Migrations
{
    /// <inheritdoc />
    public partial class JuntandoTodasAsTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Salario",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

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

            migrationBuilder.CreateTable(
                name: "Garagem",
                columns: table => new
                {
                    IdVaga = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlacaVaga = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Documento");

            migrationBuilder.DropTable(
                name: "Garagem");

            migrationBuilder.AlterColumn<double>(
                name: "Salario",
                table: "Funcionarios",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
