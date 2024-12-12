﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Pablo_Ortiz.Data;
using Pablo_Ortiz.Modelos;

namespace Pablo_Ortiz.Controllers
{
    public class ProveedorsController : Controller
    {
        private readonly PabloOrtizBDContext _context;

        public ProveedorsController(PabloOrtizBDContext context)
        {
            _context = context;
        }

        // GET: Proveedors
        public async Task<IActionResult> Index()
        {
            var pabloOrtizBDContext = _context.Proveedors.Include(p => p.Ubicacion);
            return View(await pabloOrtizBDContext.ToListAsync());
        }

        // GET: Proveedors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Proveedors == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedors
                .Include(p => p.Ubicacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return View(proveedor);
        }

        // GET: Proveedors/Create
        public IActionResult Create()
        {
            ViewData["UbicacionId"] = new SelectList(_context.Ubicacions, "Id", "Id");
            return View();
        }

        // POST: Proveedors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rut,Nombre,UbicacionId")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(proveedor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2627) 
                {
                    ModelState.AddModelError(string.Empty, "El RUT ya está registrado en el sistema, utiliza otro por favor");
                }
            }
            ViewData["UbicacionId"] = new SelectList(_context.Ubicacions, "Id", "Id", proveedor.UbicacionId);
            return View(proveedor);
        }

        // GET: Proveedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Proveedors == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedors.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            ViewData["UbicacionId"] = new SelectList(_context.Ubicacions, "Id", "Id", proveedor.UbicacionId);
            return View(proveedor);
        }

        // POST: Proveedors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rut,Nombre,UbicacionId")] Proveedor proveedor)
        {
            if (id != proveedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedorExists(proveedor.Id))
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
            ViewData["UbicacionId"] = new SelectList(_context.Ubicacions, "Id", "Id", proveedor.UbicacionId);
            return View(proveedor);
        }

        // GET: Proveedors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Proveedors == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedors
                .Include(p => p.Ubicacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return View(proveedor);
        }

        // POST: Proveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Proveedors == null)
            {
                return Problem("Entity set 'PabloOrtizBDContext.Proveedors'  is null.");
            }
            var proveedor = await _context.Proveedors.FindAsync(id);
            if (proveedor != null)
            {
                _context.Proveedors.Remove(proveedor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProveedorExists(int id)
        {
            return (_context.Proveedors?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // Acción para el reporte de proveedores por ciudad
        public async Task<IActionResult> ReporteProveedoresPorCiudad()
        {
            var reporte = await _context.Proveedors
                .Include(p => p.Ubicacion)
                .GroupBy(p => p.Ubicacion.Nombre)
                .Select(g => new
                {
                    Ciudad = g.Key,
                    TotalProveedores = g.Count()
                })
                .OrderByDescending(r => r.TotalProveedores)
                .ToListAsync();

            return View(reporte);
        }
    }
}
