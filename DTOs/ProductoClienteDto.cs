using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_careluna.DTOs
{
    public class ProductoClienteDto
    {
        public int ClienteId { get; set; }
        public List<int> ProductosId { get; set; }
        public decimal pc_Precio { get; set; }
    }
}