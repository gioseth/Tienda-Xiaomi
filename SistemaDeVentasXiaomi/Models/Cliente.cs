using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeVentasXiaomi.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        [Required]
        public int? CI {  get; set; }
        public string? Nombre { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Telefono { get; set; }
        [Required]
        public string? Direccion { get; set; }

        //atributos computados
        [NotMapped]
        public string? Info { get { return $"{CI} - {Nombre}"; } }

        // Relación uno a muchos con Ventas
        public ICollection<Venta>? Ventas { get; set; }
    }

}
