using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_careluna.DTOs
{
    public class ProductoDto
    {
        public int? pro_Id { get; set; }
        public string pro_Nombre { get; set; } = string.Empty;
        public decimal pro_Precio { get; set; }
        public string? pro_Descripcion { get; set; }
        public string? pro_imagen { get; set; }
        public char? pro_Estado { get; set; }
    }
}