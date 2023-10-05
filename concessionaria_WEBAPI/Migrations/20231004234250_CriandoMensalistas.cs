using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace concessionaria_WEBAPI.Migrations
{
    /// <inheritdoc />
    public partial class CriandoMensalistas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mensalista",
                columns: table => new
                {
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    diaDaLocacao = table.Column<string>(type: "TEXT", nullable: true),
                    CpfMensalista = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensalista", x => x.Status);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mensalista");
        }
    }
}
