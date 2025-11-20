using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_careluna.DTOs;
using api_careluna.Models;
using api_careluna.Responses;
using api_careluna.Services.Productos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace api_careluna.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ILogger<ProductosController> _logger;
        private readonly IProductosServices _productosServices;

        public ProductosController(ILogger<ProductosController> logger, IProductosServices productosServices)
        {
            _logger = logger;
            _productosServices = productosServices;
        }

        [HttpGet(Name = "consultar/productos")]
        public async Task<IActionResult> ConsultarProductos()
        {
            var producto = await _productosServices.ConsultarProductos();
            if (producto == null)
            {
                var response = ApiResponseFactory.Create<Object>(
                    StatusCodes.Status204NoContent,
                    "No hay productos disponibles"
                );
                return StatusCode(response.StatusCode, response);
            }

            var okResponse = ApiResponseFactory.Create(
                StatusCodes.Status200OK,
                "Productos obtenidos correctamente",
                producto
            );
            return StatusCode(okResponse.StatusCode, okResponse);
        }

        [HttpPost(Name = "guardar/producto")]
        public async Task<IActionResult> GuardarProducto([FromBody] ProductosModel Data)
        {
            if (!ModelState.IsValid)
            {
                var errorResponse = ApiResponseFactory.Create<Object>(
                    StatusCodes.Status400BadRequest,
                    "Datos invalidos",
                    null,
                    ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList()
                );

                return StatusCode(errorResponse.StatusCode, errorResponse);
            }

            var nuevoProducto = await _productosServices.GuardarProducto(Data);
            var okResponse = ApiResponseFactory.Create(
                StatusCodes.Status201Created,
                "Producto creado correctamente",
                nuevoProducto
            );
            return StatusCode(okResponse.StatusCode, okResponse);

        }

    }
}