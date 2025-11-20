using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_careluna.DTOs
{
    public class ClienteDto
    {
        public string cli_Nombre { get; set; } = string.Empty;
        public string cli_Celular { get; set; }
        public string cli_Direccion { get; set; }
        public string cli_RazonSocial { get; set; }
    }
}