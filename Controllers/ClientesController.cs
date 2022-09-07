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
    public class ClientesController : Controller
    {
        private readonly projectContext _context;

        public ClientesController(projectContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.Clientes.Include(c => c.IdCiudadNavigation).Include(c => c.IdDireccionNavigation).Include(c => c.IdTiendaNavigation).Include(c => c.IdTipoVentaNavigation).Include(c => c.TipoClienteNavigation);
            return View(await projectContext.ToListAsync());
        }

        // GET: Clientes/Details/5
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

        private bool ClienteExists(int id)
        {
          return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
