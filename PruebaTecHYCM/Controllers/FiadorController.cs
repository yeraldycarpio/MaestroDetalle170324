using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTecHYCM.Models;

namespace PruebaTecHYCM.Controllers
{
    public class FiadorController : Controller
    {
        private readonly PruebaTecHYCMDBContext _context;

        public FiadorController(PruebaTecHYCMDBContext context)
        {
            _context = context;
        }

        // GET: Fiador
        public async Task<IActionResult> Index()
        {
              return _context.Fiadors != null ? 
                          View(await _context.Fiadors.ToListAsync()) :
                          Problem("Entity set 'PruebaTecHYCMDBContext.Fiadors'  is null.");
        }

        // GET: Fiador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fiadors == null)
            {
                return NotFound();
            }

            var fiador = await _context.Fiadors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fiador == null)
            {
                return NotFound();
            }

            return View(fiador);
        }

        // GET: Fiador/Create
        public IActionResult Create()
        {
            var Fiador = new Fiador();
            Fiador.FechaNacimiento = DateTime.Now;
            Fiador.ReferenciasFamiliares = new List<ReferenciasFamiliare>();
            Fiador.ReferenciasFamiliares.Add(new ReferenciasFamiliare
            {
               
            });
            ViewBag.Accion = "Create";
            return View(Fiador);
        }

        // POST: Fiador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion,Telefono,Correo,Ocupacion,IngresoMensual,FechaNacimiento")] Fiador fiador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fiador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fiador);
        }

        // GET: Fiador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fiadors == null)
            {
                return NotFound();
            }

            var fiador = await _context.Fiadors.FindAsync(id);
            if (fiador == null)
            {
                return NotFound();
            }
            return View(fiador);
        }

        // POST: Fiador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion,Telefono,Correo,Ocupacion,IngresoMensual,FechaNacimiento")] Fiador fiador)
        {
            if (id != fiador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fiador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiadorExists(fiador.Id))
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
            return View(fiador);
        }

        // GET: Fiador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fiadors == null)
            {
                return NotFound();
            }

            var fiador = await _context.Fiadors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fiador == null)
            {
                return NotFound();
            }

            return View(fiador);
        }

        // POST: Fiador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fiadors == null)
            {
                return Problem("Entity set 'PruebaTecHYCMDBContext.Fiadors'  is null.");
            }
            var fiador = await _context.Fiadors.FindAsync(id);
            if (fiador != null)
            {
                _context.Fiadors.Remove(fiador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiadorExists(int id)
        {
          return (_context.Fiadors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
