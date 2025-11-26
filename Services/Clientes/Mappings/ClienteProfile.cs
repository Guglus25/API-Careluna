using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_careluna.DTOs;
using api_careluna.Models;
using AutoMapper;

namespace api_careluna.Services.Clientes.Mappings
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            // DTO → Modelo
            CreateMap<ClienteDto, ClientesModel>();

            // Modelo → DTO 
            CreateMap<ClientesModel, ClienteDto>();
        }
    }
}