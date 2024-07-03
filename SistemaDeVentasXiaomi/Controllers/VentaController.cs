using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDeVentasXiaomi.Contexto;
using SistemaDeVentasXiaomi.Models;

namespace SistemaDeVentasXiaomi.Controllers
{
    public class VentaController : Controller
    {
        private readonly MyContext _context;

        public VentaController(MyContext context)
        {
            _context = context;
        }

        // GET: Venta
        public async Task<IActionResult> Index()
        {
            var myContext = _context.Ventas.Include(v => v.Cliente).Include(v => v.Televisor);
            return View(await myContext.ToListAsync());
        }

        // GET: Venta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Televisor)
                .FirstOrDefaultAsync(m => m.VentaId == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Venta/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Info");
            ViewData["TelevisorId"] = new SelectList(_context.Televisores, "TelevisorId", "Info");
            return View();
        }

        // POST: Venta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentaId,NroVenta,FechaVenta,Mes,Anio,Detalle,Cantidad,PrecioUnidad,Total,ClienteId,TelevisorId")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                venta.FechaVenta = DateOnly.FromDateTime(DateTime.Now);
                venta.NroVenta = GetNumero();
                
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Direccion", venta.ClienteId);
            ViewData["TelevisorId"] = new SelectList(_context.Televisores, "TelevisorId", "TelevisorId", venta.TelevisorId);
            return View(venta);
        }

        private int GetNumero()
        {
            if(_context.Ventas.ToList().Count > 0)
                return _context.Ventas.Max(i => i.NroVenta + 1);
            return 1;
        }



        // GET: Venta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Televisor)
                .FirstOrDefaultAsync(m => m.VentaId == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.VentaId == id);
        }
    }
}
