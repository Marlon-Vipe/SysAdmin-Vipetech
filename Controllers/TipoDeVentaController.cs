using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using empleados.Models;

namespace empleados.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class TipoDeVentaController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly projectContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TipoDeVentaController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public TipoDeVentaController(projectContext context)
        {
            _context = context;
        }

        // GET: TipoDeVenta
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
              return _context.TipoDeVenta != null ? 
                          View(await _context.TipoDeVenta.ToListAsync()) :
                          Problem("Entity set 'projectContext.TipoDeVenta'  is null.");
        }

        // GET: TipoDeVenta/Details/5
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoDeVenta == null)
            {
                return NotFound();
            }

            var tipoDeVentum = await _context.TipoDeVenta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDeVentum == null)
            {
                return NotFound();
            }

            return View(tipoDeVentum);
        }

        // GET: TipoDeVenta/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDeVenta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the specified tipo de ventum.
        /// </summary>
        /// <param name="tipoDeVentum">The tipo de ventum.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] TipoDeVentum tipoDeVentum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeVentum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDeVentum);
        }

        // GET: TipoDeVenta/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoDeVenta == null)
            {
                return NotFound();
            }

            var tipoDeVentum = await _context.TipoDeVenta.FindAsync(id);
            if (tipoDeVentum == null)
            {
                return NotFound();
            }
            return View(tipoDeVentum);
        }

        // POST: TipoDeVenta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="tipoDeVentum">The tipo de ventum.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] TipoDeVentum tipoDeVentum)
        {
            if (id != tipoDeVentum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeVentum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeVentumExists(tipoDeVentum.Id))
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
            return View(tipoDeVentum);
        }

        // GET: TipoDeVenta/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoDeVenta == null)
            {
                return NotFound();
            }

            var tipoDeVentum = await _context.TipoDeVenta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDeVentum == null)
            {
                return NotFound();
            }

            return View(tipoDeVentum);
        }

        // POST: TipoDeVenta/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoDeVenta == null)
            {
                return Problem("Entity set 'projectContext.TipoDeVenta'  is null.");
            }
            var tipoDeVentum = await _context.TipoDeVenta.FindAsync(id);
            if (tipoDeVentum != null)
            {
                _context.TipoDeVenta.Remove(tipoDeVentum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Tipoes the de ventum exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private bool TipoDeVentumExists(int id)
        {
          return (_context.TipoDeVenta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
