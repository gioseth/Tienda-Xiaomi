using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeVentasXiaomi.Models
{
    public class Venta
    {
        [Key]
        public int VentaId { get; set; }
        public int NroVenta {  get; set; }
        [Column(TypeName = "date")]
        [Required]
        public DateOnly FechaVenta { get; set; }
        [Required]
        public int Mes {  get; set; }
        [Required]
        public int Anio { get; set; }
        [Required]
        public string? Detalle { get; set; }
        public int Cantidad { get; set; }
        [Precision(10,2)]
        public decimal PrecioUnidad { get; set; }
        [Precision(10, 2)]
        public decimal Total { get; set; }

        //Relaciones

        public int ClienteId { get; set; }
        public int TelevisorId { get; set; }
        public Cliente? Cliente { get; set; }
        public Televisor? Televisor { get; set; }
    }

}
