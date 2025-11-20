using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api_careluna.Models;

namespace api_careluna.Data
{
    [Table("Pedidos")]
    public class PedidosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ped_Id { get; set; }
        public int cli_id { get; set; }        
        public DateTime ped_Fecha { get; set; } = DateTime.Now;
        public decimal ped_Total { get; set; }

        [ForeignKey("cli_id")]
        public ClientesModel Cliente { get; set; }
        public ICollection<PedidoDetalleModel> Productos { get; set; }

    }
}