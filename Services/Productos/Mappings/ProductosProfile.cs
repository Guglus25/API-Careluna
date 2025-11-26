using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_careluna.DTOs;
using api_careluna.Models;
using AutoMapper;

namespace api_careluna.Services.Productos.Mappings
{
    public class ProductosProfile : Profile
    {
        public ProductosProfile()
        {
            // DTO → Modelo
            CreateMap<ProductoDto, ProductosModel>();

            // Modelo → DTO 
            CreateMap<ProductosModel, ProductoDto>();
        }

    }
}