using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pablo_Ortiz.Modelos
{
    // Representa una ubicación en el sistema //
    public partial class Ubicacion
    {
        public Ubicacion()
        {
            Proveedors = new HashSet<Proveedor>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = null!; // Nombre de la ubicación

        public virtual ICollection<Proveedor> Proveedors { get; set; }
    }
}
