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
    public class ClientesController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly projectContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientesController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ClientesController(projectContext context)
        {
            _context = context;
        }

        // GET: Clientes
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.Clientes.Include(c => c.IdCiudadNavigation).Include(c => c.IdDireccionNavigation).Include(c => c.IdTiendaNavigation).Include(c => c.IdTipoVentaNavigation).Include(c => c.TipoClienteNavigation);
            return View(await projectContext.ToListAsync());
        }

        // GET: Clientes/Details/5
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.IdCiudadNavigation)
                .Include(c => c.IdDireccionNavigation)
                .Include(c => c.IdTiendaNavigation)
                .Include(c => c.IdTipoVentaNavigation)
                .Include(c => c.TipoClienteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewData["IdCiudad"] = new SelectList(_context.Ciudads, "Id", "Id");
            ViewData["IdDireccion"] = new SelectList(_context.Direccions, "Id", "Id");
            ViewData["IdTienda"] = new SelectList(_context.Tienda, "Id", "Id");
            ViewData["IdTipoVenta"] = new SelectList(_context.TipoDeVenta, "Id", "Id");
            ViewData["TipoCliente"] = new SelectList(_context.TipoClientes, "Id", "Id");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the specified cliente.
        /// </summary>
        /// <param name="cliente">The cliente.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Cedula,Telefono,IdCiudad,IdDireccion,IdTienda,IdTipoVenta,TipoCliente")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCiudad"] = new SelectList(_context.Ciudads, "Id", "Id", cliente.IdCiudad);
            ViewData["IdDireccion"] = new SelectList(_context.Direccions, "Id", "Id", cliente.IdDireccion);
            ViewData["IdTienda"] = new SelectList(_context.Tienda, "Id", "Id", cliente.IdTienda);
            ViewData["IdTipoVenta"] = new SelectList(_context.TipoDeVenta, "Id", "Id", cliente.IdTipoVenta);
            ViewData["TipoCliente"] = new SelectList(_context.TipoClientes, "Id", "Id", cliente.TipoCliente);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["IdCiudad"] = new SelectList(_context.Ciudads, "Id", "Id", cliente.IdCiudad);
            ViewData["IdDireccion"] = new SelectList(_context.Direccions, "Id", "Id", cliente.IdDireccion);
            ViewData["IdTienda"] = new SelectList(_context.Tienda, "Id", "Id", cliente.IdTienda);
            ViewData["IdTipoVenta"] = new SelectList(_context.TipoDeVenta, "Id", "Id", cliente.IdTipoVenta);
            ViewData["TipoCliente"] = new SelectList(_context.TipoClientes, "Id", "Id", cliente.TipoCliente);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cliente">The cliente.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Cedula,Telefono,IdCiudad,IdDireccion,IdTienda,IdTipoVenta,TipoCliente")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            ViewData["IdCiudad"] = new SelectList(_context.Ciudads, "Id", "Id", cliente.IdCiudad);
            ViewData["IdDireccion"] = new SelectList(_context.Direccions, "Id", "Id", cliente.IdDireccion);
            ViewData["IdTienda"] = new SelectList(_context.Tienda, "Id", "Id", cliente.IdTienda);
            ViewData["IdTipoVenta"] = new SelectList(_context.TipoDeVenta, "Id", "Id", cliente.IdTipoVenta);
            ViewData["TipoCliente"] = new SelectList(_context.TipoClientes, "Id", "Id", cliente.TipoCliente);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.IdCiudadNavigation)
                .Include(c => c.IdDireccionNavigation)
                .Include(c => c.IdTiendaNavigation)
                .Include(c => c.IdTipoVentaNavigation)
                .Include(c => c.TipoClienteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'projectContext.Clientes'  is null.");
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Clientes the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private bool ClienteExists(int id)
        {
          return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
