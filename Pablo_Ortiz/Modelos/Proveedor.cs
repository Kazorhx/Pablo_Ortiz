using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pablo_Ortiz.Modelos
{
    
    //Este modelo representa un proveedor en el sistema//
    public partial class Proveedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Rut es obligatorio.")]
        public string Rut { get; set; } = null!;

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "La ubicación es obligatoria.")]
        public int UbicacionId { get; set; }

        public virtual Ubicacion? Ubicacion { get; set; } = null!;
    }
}
