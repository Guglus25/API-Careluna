using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_careluna.DTOs;
using api_careluna.Models;

namespace api_careluna.Services.Productos.Interfaces
{
    public interface IProductosServices
    {
        Task<List<ProductoDto>> ConsultarProductos();
        Task<ProductoDto> ConsultarProductoId(int id);
        Task<ProductoDto> GuardarProducto(ProductoDto Data);
        Task<bool> EliminarProducto(int id);
    }
}