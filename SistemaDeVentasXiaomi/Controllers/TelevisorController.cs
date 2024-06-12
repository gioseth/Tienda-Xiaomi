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
    public class TelevisorController : Controller
    {
        private readonly MyContext _context;

        public TelevisorController(MyContext context)
        {
            _context = context;
        }

        // GET: Televisor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Televisores.ToListAsync());
        }

        // GET: Televisor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var televisor = await _context.Televisores
                .FirstOrDefaultAsync(m => m.TelevisorId == id);
            if (televisor == null)
            {
                return NotFound();
            }

            return View(televisor);
        }

        // GET: Televisor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Televisor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TelevisorId,Modelo,Precio,Descripcion,Stock")] Televisor televisor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(televisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(televisor);
        }

        // GET: Televisor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var televisor = await _context.Televisores.FindAsync(id);
            if (televisor == null)
            {
                return NotFound();
            }
            return View(televisor);
        }

        // POST: Televisor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TelevisorId,Modelo,Precio,Descripcion,Stock")] Televisor televisor)
        {
            if (id != televisor.TelevisorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(televisor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelevisorExists(televisor.TelevisorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(televisor);
        }

        // GET: Televisor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var televisor = await _context.Televisores
                .FirstOrDefaultAsync(m => m.TelevisorId == id);
            if (televisor == null)
            {
                return NotFound();
            }

            return View(televisor);
        }

        // POST: Televisor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var televisor = await _context.Televisores.FindAsync(id);
            if (televisor != null)
            {
                _context.Televisores.Remove(televisor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelevisorExists(int id)
        {
            return _context.Televisores.Any(e => e.TelevisorId == id);
        }
    }
}
