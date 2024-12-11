using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pablo_Ortiz.Modelos
{
    public partial class Proveedor
    {
        [Key]
        public int Id { get; set; }
        public string Rut { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int UbicacionId { get; set; }

        public virtual Ubicacion? Ubicacion { get; set; } = null!;
    }
}
