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
    public class TiendaController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly projectContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TiendaController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public TiendaController(projectContext context)
        {
            _context = context;
        }

        // GET: Tienda
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
              return _context.Tienda != null ? 
                          View(await _context.Tienda.ToListAsync()) :
                          Problem("Entity set 'projectContext.Tienda'  is null.");
        }

        // GET: Tienda/Details/5
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tienda == null)
            {
                return NotFound();
            }

            var tiendum = await _context.Tienda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiendum == null)
            {
                return NotFound();
            }

            return View(tiendum);
        }

        // GET: Tienda/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tienda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the specified tiendum.
        /// </summary>
        /// <param name="tiendum">The tiendum.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Tiendum tiendum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiendum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiendum);
        }

        // GET: Tienda/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tienda == null)
            {
                return NotFound();
            }

            var tiendum = await _context.Tienda.FindAsync(id);
            if (tiendum == null)
            {
                return NotFound();
            }
            return View(tiendum);
        }

        // POST: Tienda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="tiendum">The tiendum.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Tiendum tiendum)
        {
            if (id != tiendum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiendum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiendumExists(tiendum.Id))
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
            return View(tiendum);
        }

        // GET: Tienda/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tienda == null)
            {
                return NotFound();
            }

            var tiendum = await _context.Tienda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiendum == null)
            {
                return NotFound();
            }

            return View(tiendum);
        }

        // POST: Tienda/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tienda == null)
            {
                return Problem("Entity set 'projectContext.Tienda'  is null.");
            }
            var tiendum = await _context.Tienda.FindAsync(id);
            if (tiendum != null)
            {
                _context.Tienda.Remove(tiendum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Tiendums the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private bool TiendumExists(int id)
        {
          return (_context.Tienda?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
