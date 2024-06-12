using System.ComponentModel.DataAnnotations;

namespace SistemaDeVentasXiaomi.Models
{
    public class Televisor
    {
        [Key]
        public int TelevisorId { get; set; }
        public string? Modelo { get; set; }
        [Required]
        public decimal Precio { get; set; }
        public string? Descripcion { get; set; }
        [Required]
        public int Stock { get; set; }

        // Relación uno a muchos con Ventas
        public ICollection<Venta> Ventas { get; set; }
        
    }

}
