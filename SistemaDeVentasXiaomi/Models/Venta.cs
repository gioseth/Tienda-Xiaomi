using System.ComponentModel.DataAnnotations;

namespace SistemaDeVentasXiaomi.Models
{
    public class Venta
    {
        [Key]
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
        public int TelevisorId { get; set; }
        public Televisor Televisor { get; set; }
        public DateTime FechaVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }

}
