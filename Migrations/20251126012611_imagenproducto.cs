using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_careluna.Migrations
{
    /// <inheritdoc />
    public partial class imagenproducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pro_imagen",
                table: "Productos",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pro_imagen",
                table: "Productos");
        }
    }
}
