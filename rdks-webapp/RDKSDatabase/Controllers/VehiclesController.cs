using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RDKSDatabase.Data;
using RDKSDatabase.Models;

namespace RDKSDatabase.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly RDKSDatabaseContext _context;

        public VehiclesController(RDKSDatabaseContext context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index(string searchString1, string searchString2)
        {

            ViewData["CurrentFilter1"] = searchString1;
            ViewData["CurrentFilter2"] = searchString2;

            var vehicle = from v in _context.Vehicle
                          select v;

            if (!String.IsNullOrEmpty(searchString1) && String.IsNullOrEmpty(searchString2))
            {
                vehicle = vehicle.Where(v => v.LICENSE_PLATE.Contains(searchString1));
            }
            if (String.IsNullOrEmpty(searchString1) && !String.IsNullOrEmpty(searchString2))
            {
                vehicle = vehicle.Where(v => v.BADGE.Contains(searchString2));
            }
            if (!String.IsNullOrEmpty(searchString1) && !String.IsNullOrEmpty(searchString2))
            {
                vehicle = vehicle.Where(v => v.LICENSE_PLATE.Contains(searchString1) && v.BADGE.Contains(searchString2));
            }


            return View(await vehicle.AsNoTracking().ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .Include(v => v.Customer)
                .FirstOrDefaultAsync(m => m.LICENSE_PLATE == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            ViewData["CUS_ID"] = new SelectList(_context.Customer, "CUS_ID", "CUS_FNAME");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LICENSE_PLATE,CUS_ID,DESCRIPTION,BADGE,NOTES,NOTES_2")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CUS_ID"] = new SelectList(_context.Customer, "CUS_ID", "CUS_FNAME", vehicle.CUS_ID);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["CUS_ID"] = new SelectList(_context.Customer, "CUS_ID", "CUS_FNAME", vehicle.CUS_ID);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LICENSE_PLATE,CUS_ID,DESCRIPTION,BADGE,NOTES,NOTES_2")] Vehicle vehicle)
        {
            if (id != vehicle.LICENSE_PLATE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.LICENSE_PLATE))
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
            ViewData["CUS_ID"] = new SelectList(_context.Customer, "CUS_ID", "CUS_FNAME", vehicle.CUS_ID);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .Include(v => v.Customer)
                .FirstOrDefaultAsync(m => m.LICENSE_PLATE == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Vehicle == null)
            {
                return Problem("Entity set 'RDKSDatabaseContext.Vehicle'  is null.");
            }
            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle != null)
            {
                _context.Vehicle.Remove(vehicle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(string id)
        {
          return (_context.Vehicle?.Any(e => e.LICENSE_PLATE == id)).GetValueOrDefault();
        }
    }
}
