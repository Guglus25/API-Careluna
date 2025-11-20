using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_careluna.DTOs
{
    public class PedidoDto
    {
        public int ClienteId { get; set; }
        public DateTime ped_Fecha { get; set; } = DateTime.Now;
        public List<int>? ProductosId { get; set; } = new();
        public decimal ped_Total { get; set; }
    }
}