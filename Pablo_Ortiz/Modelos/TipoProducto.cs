using System;
using System.Collections.Generic;

namespace Pablo_Ortiz.Modelos
{
    public partial class TipoProducto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
    }
}
