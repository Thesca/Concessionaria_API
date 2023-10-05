using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace concessionaria_WEBAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlteradoVeiculos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Veiculos",
                type: "INTEGER",
                maxLength: 30,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 30,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Veiculos",
                type: "TEXT",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 30);
        }
    }
}
