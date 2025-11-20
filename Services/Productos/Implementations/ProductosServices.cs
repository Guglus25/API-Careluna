using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_careluna.Data;
using api_careluna.Models;
using api_careluna.Services.Productos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_careluna.Services.Productos.Implementations
{
    public class ProductosServices : IProductosServices
    {
        private readonly AppDbContext _context;

        public ProductosServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductosModel>> ConsultarProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<ProductosModel?> ConsultarProductoId(int id)
        {
            return await _context.Productos.FirstOrDefaultAsync(p => p.pro_Id == id);
        }

        public async Task<ProductosModel> GuardarProducto(ProductosModel Data)
        {
            _context.Productos.Add(Data);
            await _context.SaveChangesAsync();
            return Data;
        }
        public async Task<bool> EliminarProducto(int id)
        {
            var producto = _context.Producto.FirstOrDefaultAsync(id);
            if (producto == null) return false;

            producto.pro_Estado = "I";
            _context.Producto.Update(producto);
            await _context.SaveChangesAsync();

            return true;
        }




    }
}