using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pablo_Ortiz.Modelos
{
    // Representa un tipo de producto en el sistema //
    public partial class TipoProducto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string? Descripcion { get; set; } = null!;

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public string? Estado { get; set; } = null!;
    }
}
