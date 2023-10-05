using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace concessionaria_WEBAPI.Migrations
{
    /// <inheritdoc />
    public partial class ConsertandoMensalistas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Mensalista",
                table: "Mensalista");

            migrationBuilder.AlterColumn<int>(
                name: "CpfMensalista",
                table: "Mensalista",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Mensalista",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mensalista",
                table: "Mensalista",
                column: "CpfMensalista");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Mensalista",
                table: "Mensalista");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Mensalista",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CpfMensalista",
                table: "Mensalista",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mensalista",
                table: "Mensalista",
                column: "Status");
        }
    }
}
