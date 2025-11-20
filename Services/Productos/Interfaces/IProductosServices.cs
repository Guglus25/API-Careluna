using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_careluna.Models;

namespace api_careluna.Services.Productos.Interfaces
{
    public interface IProductosServices
    {
        Task<List<ProductosModel>> ConsultarProductos();
        Task<ProductosModel> GuardarProducto(ProductosModel Data);
    }
}