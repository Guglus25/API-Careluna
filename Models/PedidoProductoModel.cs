using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_careluna.Data;

namespace api_careluna.Models
{
    public class PedidoProductoModel
    {
        public int Id { get; set; }

        public int ped_id { get; set; }
        public PedidosModel Pedido { get; set; }

        public int pc_id { get; set; }
        public ProductoClienteModel ClienteProducto { get; set; }

        public int Cantidad { get; set; }
        public decimal PrecioUsado { get; set; } // precio del momento
    }

}