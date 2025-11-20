using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using api_careluna.Data;

namespace api_careluna.Models
{
    [Table("Productos")]
    public class ProductosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int pro_Id { get; set; }
        public string pro_Nombre { get; set; } = string.Empty;
        public decimal pro_Precio { get; set; }
        public string? pro_Descripcion { get; set; }

        public List<ProductoClienteModel>? productoClientes { get; set; }

    }
}