using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaDeVentasXiaomi.Models;

namespace SistemaDeVentasXiaomi.Contexto
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Televisor> Televisores { get; set; }
        public DbSet<Venta> Ventas { get; set; }
    }
}
