using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RDKSDatabase.Models;
using RDKSDatabase.Data;

namespace RDKSDatabase.Controllers
{
    /// <summary>
    /// The controller of HWY37N_HAZELTON.
    /// </summary>
    public class HWY37N_HAZELTONController : Controller
    {
        private readonly RDKSDatabaseContext _context;

        public HWY37N_HAZELTONController(RDKSDatabaseContext context)
        {
            _context = context;
        }

        // GET: HWY37N_HAZELTON
        public async Task<IActionResult> Index(string sortOrder, DateTime searchString1, DateTime searchString2)
        {
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter1"] = searchString1;
            ViewData["CurrentFilter2"] = searchString2;
            string defaultDate = "0001";

            var hazelton = from haz in _context.HWY37N_HAZELTON
                               select haz;

            if (searchString1.ToString().Contains(defaultDate) || searchString2.ToString().Contains(defaultDate))
            {
                hazelton = hazelton.Select(x => x);
            }
            else
            {
                hazelton = hazelton.Where(haz => haz.HWY_HAZ_DATE >= searchString1 && haz.HWY_HAZ_DATE <= searchString2);
            }

            switch (sortOrder)
            {
                case "date_desc":
                    hazelton = hazelton.OrderByDescending(haz => haz.HWY_HAZ_DATE);
                    break;
                default:
                    hazelton = hazelton.OrderBy(haz => haz.HWY_HAZ_DATE);
                    break;
            }
            return View(await hazelton.AsNoTracking().ToListAsync());
        }

        // GET: HWY37N_HAZELTON/Details/5
        public async Task<IActionResult> Details(DateTime? id)
        {
            if (id == null || _context.HWY37N_HAZELTON == null)
            {
                return NotFound();
            }

            var hWY37N_HAZELTON = await _context.HWY37N_HAZELTON
                .FirstOrDefaultAsync(m => m.HWY_HAZ_DATE == id);
            if (hWY37N_HAZELTON == null)
            {
                return NotFound();
            }

            return View(hWY37N_HAZELTON);
        }

        // GET: HWY37N_HAZELTON/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HWY37N_HAZELTON/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HWY_HAZ_DATE,HWY_HAZ_EST_OCC_TONNES,HWY_HAZ_OCC_BIN_BILLING,HWY_HAZ_SCRAP_METAL_TONNES,HWY_HAZ_TIRE_COUNTS,HWY_HAZ_TIRE_COLLECTION_CHARGES,HWY_HAZ_FREON_REMOVAL_CHARGES,HWY_HAZ_MARR_INCOME,HWY_HAZ_ABC_INCOME")] HWY37N_HAZELTON hWY37N_HAZELTON)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hWY37N_HAZELTON);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hWY37N_HAZELTON);
        }

        // GET: HWY37N_HAZELTON/Edit/5
        public async Task<IActionResult> Edit(DateTime? id)
        {
            if (id == null || _context.HWY37N_HAZELTON == null)
            {
                return NotFound();
            }

            var hWY37N_HAZELTON = await _context.HWY37N_HAZELTON.FindAsync(id);
            if (hWY37N_HAZELTON == null)
            {
                return NotFound();
            }
            return View(hWY37N_HAZELTON);
        }

        // POST: HWY37N_HAZELTON/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DateTime id, [Bind("HWY_HAZ_DATE,HWY_HAZ_EST_OCC_TONNES,HWY_HAZ_OCC_BIN_BILLING,HWY_HAZ_SCRAP_METAL_TONNES,HWY_HAZ_TIRE_COUNTS,HWY_HAZ_TIRE_COLLECTION_CHARGES,HWY_HAZ_FREON_REMOVAL_CHARGES,HWY_HAZ_MARR_INCOME,HWY_HAZ_ABC_INCOME")] HWY37N_HAZELTON hWY37N_HAZELTON)
        {
            if (id != hWY37N_HAZELTON.HWY_HAZ_DATE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hWY37N_HAZELTON);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HWY37N_HAZELTONExists(hWY37N_HAZELTON.HWY_HAZ_DATE))
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
            return View(hWY37N_HAZELTON);
        }

        // GET: HWY37N_HAZELTON/Delete/5
        public async Task<IActionResult> Delete(DateTime? id)
        {
            if (id == null || _context.HWY37N_HAZELTON == null)
            {
                return NotFound();
            }

            var hWY37N_HAZELTON = await _context.HWY37N_HAZELTON
                .FirstOrDefaultAsync(m => m.HWY_HAZ_DATE == id);
            if (hWY37N_HAZELTON == null)
            {
                return NotFound();
            }

            return View(hWY37N_HAZELTON);
        }

        // POST: HWY37N_HAZELTON/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime id)
        {
            if (_context.HWY37N_HAZELTON == null)
            {
                return Problem("Entity set 'RDKSDatabaseContext.HWY37N_HAZELTON'  is null.");
            }
            var hWY37N_HAZELTON = await _context.HWY37N_HAZELTON.FindAsync(id);
            if (hWY37N_HAZELTON != null)
            {
                _context.HWY37N_HAZELTON.Remove(hWY37N_HAZELTON);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HWY37N_HAZELTONExists(DateTime id)
        {
          return (_context.HWY37N_HAZELTON?.Any(e => e.HWY_HAZ_DATE == id)).GetValueOrDefault();
        }
    }
}
