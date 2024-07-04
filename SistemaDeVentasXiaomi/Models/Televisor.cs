using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeVentasXiaomi.Models
{
    public class Televisor
    {
        [Key]
        public int TelevisorId { get; set; }
        public string? Modelo { get; set; }
        [Required]
        [Precision(10, 2)]
        public decimal Precio { get; set; }
        public string? Descripcion { get; set; }
        [Required]
        public int Stock { get; set; }
        public string? UrlFoto { get; set; }

        //para subir archivos
        [NotMapped]
        [Display (Name = "Cargar Foto")]
        public IFormFile? FotoFile { get; set; }

        [NotMapped]
        public string? Info { get { return $"{Modelo} - {Precio}"; } }


        // Relación uno a muchos con Ventas
        public ICollection<Venta>? Ventas { get; set; }
        
    }

}
