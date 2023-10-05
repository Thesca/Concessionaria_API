using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace concessionaria_WEBAPI.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataHoraPedido",
                table: "Pedido");

            migrationBuilder.RenameColumn(
                name: "ValorCompra",
                table: "Pedido",
                newName: "Valor");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Pedido",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Pedido");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Pedido",
                newName: "ValorCompra");

            migrationBuilder.AddColumn<byte[]>(
                name: "DataHoraPedido",
                table: "Pedido",
                type: "BLOB",
                rowVersion: true,
                nullable: true);
        }
    }
}
