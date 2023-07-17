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
    public class ProductosController : Controller
    {
        private readonly TextilCorpContext _context;

        public ProductosController(TextilCorpContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var textilCorpContext = _context.Productos.Include(p => p.Categorias).Include(p => p.Marcas);
            return View(await textilCorpContext.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .Include(p => p.Categorias)
                .Include(p => p.Marcas)
                .FirstOrDefaultAsync(m => m.ProductosId == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["CategoriasId"] = new SelectList(_context.Set<Categorias>(), "CategoriasId", "CategoriasId");
            ViewData["MarcasId"] = new SelectList(_context.Set<Marcas>(), "MarcasId", "MarcasId");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductosId,Nombre,Descripcion,Precio,Cantidad,Stock,Imagen,MarcasId,CategoriasId")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriasId"] = new SelectList(_context.Set<Categorias>(), "CategoriasId", "CategoriasId", productos.CategoriasId);
            ViewData["MarcasId"] = new SelectList(_context.Set<Marcas>(), "MarcasId", "MarcasId", productos.MarcasId);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }
            ViewData["CategoriasId"] = new SelectList(_context.Set<Categorias>(), "CategoriasId", "CategoriasId", productos.CategoriasId);
            ViewData["MarcasId"] = new SelectList(_context.Set<Marcas>(), "MarcasId", "MarcasId", productos.MarcasId);
            return View(productos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductosId,Nombre,Descripcion,Precio,Cantidad,Stock,Imagen,MarcasId,CategoriasId")] Productos productos)
        {
            if (id != productos.ProductosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosExists(productos.ProductosId))
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
            ViewData["CategoriasId"] = new SelectList(_context.Set<Categorias>(), "CategoriasId", "CategoriasId", productos.CategoriasId);
            ViewData["MarcasId"] = new SelectList(_context.Set<Marcas>(), "MarcasId", "MarcasId", productos.MarcasId);
            return View(productos);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .Include(p => p.Categorias)
                .Include(p => p.Marcas)
                .FirstOrDefaultAsync(m => m.ProductosId == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'TextilCorpContext.Productos'  is null.");
            }
            var productos = await _context.Productos.FindAsync(id);
            if (productos != null)
            {
                _context.Productos.Remove(productos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosExists(int id)
        {
          return (_context.Productos?.Any(e => e.ProductosId == id)).GetValueOrDefault();
        }
    }
}
