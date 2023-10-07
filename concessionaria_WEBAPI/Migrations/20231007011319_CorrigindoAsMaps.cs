using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concessionaria.cs.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindoAsMaps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Pedido");

            migrationBuilder.AlterColumn<string>(
                name: "Valor",
                table: "Veiculos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Valor",
                table: "Veiculos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Valor",
                table: "Pedido",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
