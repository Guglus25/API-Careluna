using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api_careluna.Data;

namespace api_careluna.Models
{
    [Table("Clientes")]
    public class ClientesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cli_Id { get; set; }
        public string cli_Nombre { get; set; } = string.Empty;
        public string cli_Celular { get; set; }
        public string cli_Direccion { get; set; }
        public string cli_RazonSocial { get; set; }
        public char cli_Estado { get; set; }

        public ICollection<ProductoClienteModel> ProductosPersonalizados { get; set; }
        public ICollection<PedidosModel> Pedidos { get; set; }
    }
}