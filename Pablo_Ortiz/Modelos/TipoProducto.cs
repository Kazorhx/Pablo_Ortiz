using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pablo_Ortiz.Modelos
{
    public partial class TipoProducto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
    }
}
