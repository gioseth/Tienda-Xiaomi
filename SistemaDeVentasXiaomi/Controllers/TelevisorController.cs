using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDeVentasXiaomi.Contexto;
using SistemaDeVentasXiaomi.Migrations;
using SistemaDeVentasXiaomi.Models;

namespace SistemaDeVentasXiaomi.Controllers
{
    public class TelevisorController : Controller
    {
        private readonly MyContext _context;
        IWebHostEnvironment _webHostEnvironment;

        public TelevisorController(MyContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> Create([Bind("TelevisorId,Modelo,Precio,Descripcion,Stock,UrlFoto")] Televisor televisor)
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
        public async Task<IActionResult> Edit(int id, [Bind("TelevisorId,Modelo,Precio,Descripcion,Stock,FotoFile")] Televisor televisor)
        {
            if (id != televisor.TelevisorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(televisor.FotoFile != null)
                    {
                        await GuardarImagen(televisor);
                    }
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

        private async Task GuardarImagen(Televisor televisor)
        {
            //formar el nombre de la foto
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string extension = Path.GetExtension(televisor.FotoFile!.FileName);
            string nameFoto = $"{televisor.TelevisorId}{extension}";

            televisor.UrlFoto = nameFoto;

            //copiar la foto en el proyecyo
            string path = Path.Combine($"{wwwRootPath}/fotos/", nameFoto);
            var filestream = new FileStream(path, FileMode.Create);
            await televisor.FotoFile.CopyToAsync(filestream);
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
