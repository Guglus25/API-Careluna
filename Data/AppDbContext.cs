using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_careluna.Models;
using Microsoft.EntityFrameworkCore;

namespace api_careluna.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<ProductosModel> Productos { get; set; }
        public DbSet<PedidosModel> Pedidos { get; set; }
        public DbSet<ClientesModel> Clientes { get; set; }
        public DbSet<ProductoClienteModel> ProductoCliente { get; set; }
        public DbSet<PedidoDetalleModel> PedidoProducto { get; set; }

    }
}