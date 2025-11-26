using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api_careluna.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    cli_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cli_Nombre = table.Column<string>(type: "text", nullable: false),
                    cli_Celular = table.Column<string>(type: "text", nullable: false),
                    cli_Direccion = table.Column<string>(type: "text", nullable: false),
                    cli_RazonSocial = table.Column<string>(type: "text", nullable: false),
                    cli_Estado = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.cli_Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    pro_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pro_Nombre = table.Column<string>(type: "text", nullable: false),
                    pro_Precio = table.Column<decimal>(type: "numeric", nullable: false),
                    pro_Descripcion = table.Column<string>(type: "text", nullable: true),
                    pro_Estado = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.pro_Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    ped_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cli_id = table.Column<int>(type: "integer", nullable: false),
                    ped_Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ped_Total = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.ped_Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_cli_id",
                        column: x => x.cli_id,
                        principalTable: "Clientes",
                        principalColumn: "cli_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoCliente",
                columns: table => new
                {
                    pc_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cli_id = table.Column<int>(type: "integer", nullable: false),
                    pro_id = table.Column<int>(type: "integer", nullable: false),
                    pc_Cantidad = table.Column<int>(type: "integer", nullable: false),
                    pc_Precio = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoCliente", x => x.pc_id);
                    table.ForeignKey(
                        name: "FK_ProductoCliente_Clientes_cli_id",
                        column: x => x.cli_id,
                        principalTable: "Clientes",
                        principalColumn: "cli_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoCliente_Productos_pro_id",
                        column: x => x.pro_id,
                        principalTable: "Productos",
                        principalColumn: "pro_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ped_id = table.Column<int>(type: "integer", nullable: false),
                    pc_id = table.Column<int>(type: "integer", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    PrecioUsado = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoProducto_Pedidos_ped_id",
                        column: x => x.ped_id,
                        principalTable: "Pedidos",
                        principalColumn: "ped_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoProducto_ProductoCliente_pc_id",
                        column: x => x.pc_id,
                        principalTable: "ProductoCliente",
                        principalColumn: "pc_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProducto_pc_id",
                table: "PedidoProducto",
                column: "pc_id");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProducto_ped_id",
                table: "PedidoProducto",
                column: "ped_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_cli_id",
                table: "Pedidos",
                column: "cli_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCliente_cli_id",
                table: "ProductoCliente",
                column: "cli_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCliente_pro_id",
                table: "ProductoCliente",
                column: "pro_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoProducto");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "ProductoCliente");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
