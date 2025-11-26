using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_careluna.Data;
using api_careluna.DTOs;
using api_careluna.Models;
using api_careluna.Responses;
using api_careluna.Services.Productos.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api_careluna.Services.Productos.Implementations
{
    public class ProductosServices : IProductosServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductosServices(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductoDto>> ConsultarProductos()
        {
            var ListProduct = await _context.Productos.ToListAsync();
            return _mapper.Map<List<ProductoDto>>(ListProduct);
        }

        public async Task<ProductoDto?> ConsultarProductoId(int id)
        {
            var Producto = await _context.Productos.FirstOrDefaultAsync(p => p.pro_Id == id);
            return _mapper.Map<ProductoDto>(Producto);
        }

        public async Task<ProductoDto> GuardarProducto(ProductoDto Data)
        {
            var nuevoProducto = _mapper.Map<ProductosModel>(Data);
            _context.Productos.Add(nuevoProducto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductoDto>(nuevoProducto);
        }
        public async Task<bool> EliminarProducto(int id)
        {
            ProductosModel producto = await _context.Productos.FirstOrDefaultAsync(p => p.pro_Id == id);
            if (producto == null) return false;

            producto.pro_Estado = 'I';
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();

            return true;
        }




    }
}