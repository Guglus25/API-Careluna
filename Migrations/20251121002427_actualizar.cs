using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_careluna.Migrations
{
    /// <inheritdoc />
    public partial class actualizar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "pro_Estado",
                table: "Productos",
                type: "character(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<char>(
                name: "cli_Estado",
                table: "Clientes",
                type: "character(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "pro_Estado",
                table: "Productos",
                type: "text",
                nullable: true,
                oldClrType: typeof(char),
                oldType: "character(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cli_Estado",
                table: "Clientes",
                type: "text",
                nullable: true,
                oldClrType: typeof(char),
                oldType: "character(1)",
                oldNullable: true);
        }
    }
}
