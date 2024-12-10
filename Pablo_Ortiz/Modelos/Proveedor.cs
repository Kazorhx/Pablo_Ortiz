using System;
using System.Collections.Generic;

namespace Pablo_Ortiz.Modelos
{
    public partial class Proveedor
    {
        public int Id { get; set; }
        public string Rut { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int UbicacionId { get; set; }

        public virtual Ubicacion Ubicacion { get; set; } = null!;
    }
}
