using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_careluna.Models
{
    [Table("ProductoCliente")]
    public class ProductoClienteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int pc_id { get; set; }
        public int cli_id { get; set; }
        public ClientesModel Cliente { get; set; }
        public int pro_id { get; set; }
        public ProductosModel Productos { get; set; }
        public int pc_Cantidad { get; set; }
        public decimal pc_Precio { get; set; }
    }
}