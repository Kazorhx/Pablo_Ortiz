using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pablo_Ortiz.Modelos
{
    public partial class Ubicacion
    {
        public Ubicacion()
        {
            Proveedors = new HashSet<Proveedor>();
        }

        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Proveedor> Proveedors { get; set; }
    }
}
