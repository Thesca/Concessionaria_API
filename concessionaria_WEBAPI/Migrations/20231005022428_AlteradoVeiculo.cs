using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace concessionaria_WEBAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlteradoVeiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    IdVeiculo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlacaVeiculo = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    AnoVeiculo = table.Column<int>(type: "INTEGER", maxLength: 10, nullable: false),
                    ModeloVeiculo = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Valor = table.Column<double>(type: "REAL", maxLength: 30, nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    TipoVeiculo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.IdVeiculo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
