using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TextilCorp.Data;
using TextilCorp.Models;

namespace TextilCorp.Controllers
{
    public class VentasController : Controller
    {
        private readonly TextilCorpContext _context;

        public VentasController(TextilCorpContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var textilCorpContext = _context.Ventas.Include(v => v.Clientes).Include(v => v.Productos);
            return View(await textilCorpContext.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ventas == null)
            {
                return NotFound();
            }

            var ventas = await _context.Ventas
                .Include(v => v.Clientes)
                .Include(v => v.Productos)
                .FirstOrDefaultAsync(m => m.VentasId == id);
            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["ClientesId"] = new SelectList(_context.Set<Clientes>(), "ClientesId", "ClientesId");
            ViewData["ProductosId"] = new SelectList(_context.Set<Productos>(), "ProductosId", "ProductosId");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentasId,MontoTotal,Telefono,Direccion,ClientesId,ProductosId")] Ventas ventas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientesId"] = new SelectList(_context.Set<Clientes>(), "ClientesId", "ClientesId", ventas.ClientesId);
            ViewData["ProductosId"] = new SelectList(_context.Set<Productos>(), "ProductosId", "ProductosId", ventas.ProductosId);
            return View(ventas);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ventas == null)
            {
                return NotFound();
            }

            var ventas = await _context.Ventas.FindAsync(id);
            if (ventas == null)
            {
                return NotFound();
            }
            ViewData["ClientesId"] = new SelectList(_context.Set<Clientes>(), "ClientesId", "ClientesId", ventas.ClientesId);
            ViewData["ProductosId"] = new SelectList(_context.Set<Productos>(), "ProductosId", "ProductosId", ventas.ProductosId);
            return View(ventas);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentasId,MontoTotal,Telefono,Direccion,ClientesId,ProductosId")] Ventas ventas)
        {
            if (id != ventas.VentasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentasExists(ventas.VentasId))
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
            ViewData["ClientesId"] = new SelectList(_context.Set<Clientes>(), "ClientesId", "ClientesId", ventas.ClientesId);
            ViewData["ProductosId"] = new SelectList(_context.Set<Productos>(), "ProductosId", "ProductosId", ventas.ProductosId);
            return View(ventas);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ventas == null)
            {
                return NotFound();
            }

            var ventas = await _context.Ventas
                .Include(v => v.Clientes)
                .Include(v => v.Productos)
                .FirstOrDefaultAsync(m => m.VentasId == id);
            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ventas == null)
            {
                return Problem("Entity set 'TextilCorpContext.Ventas'  is null.");
            }
            var ventas = await _context.Ventas.FindAsync(id);
            if (ventas != null)
            {
                _context.Ventas.Remove(ventas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentasExists(int id)
        {
          return (_context.Ventas?.Any(e => e.VentasId == id)).GetValueOrDefault();
        }
    }
}
