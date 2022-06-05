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
    /// The controller of HWY37N_KITWANGA.
    /// </summary>
    public class HWY37N_KITWANGAController : Controller
    {
        private readonly RDKSDatabaseContext _context;

        public HWY37N_KITWANGAController(RDKSDatabaseContext context)
        {
            _context = context;
        }

        // GET: HWY37N_KITWANGA
        public async Task<IActionResult> Index(string sortOrder, DateTime searchString1, DateTime searchString2)
        {
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter1"] = searchString1;
            ViewData["CurrentFilter2"] = searchString2;
            String defaultDate = "0001";

            var kitwanga = from kit in _context.HWY37N_KITWANGA
                               select kit;

            if (searchString1.ToString().Contains(defaultDate) || searchString2.ToString().Contains(defaultDate))
            {
                kitwanga = kitwanga.Select(x => x);
            }
            else
            {
                kitwanga = kitwanga.Where(kit => kit.HWY_KIT_DATE >= searchString1 && kit.HWY_KIT_DATE <= searchString2);
            }

            switch (sortOrder)
            {
                case "date_desc":
                    kitwanga = kitwanga.OrderByDescending(kit => kit.HWY_KIT_DATE);
                    break;
                default:
                    kitwanga = kitwanga.OrderBy(kit => kit.HWY_KIT_DATE);
                    break;
            }
            return View(await kitwanga.AsNoTracking().ToListAsync());
        }

        // GET: HWY37N_KITWANGA/Details/5
        public async Task<IActionResult> Details(DateTime? id)
        {
            if (id == null || _context.HWY37N_KITWANGA == null)
            {
                return NotFound();
            }

            var hWY37N_KITWANGA = await _context.HWY37N_KITWANGA
                .FirstOrDefaultAsync(m => m.HWY_KIT_DATE == id);
            if (hWY37N_KITWANGA == null)
            {
                return NotFound();
            }

            return View(hWY37N_KITWANGA);
        }

        // GET: HWY37N_KITWANGA/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HWY37N_KITWANGA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HWY_KIT_DATE,HWY_KIT_OCC_TONNAGE_EST,HWY_KIT_PPP_TONNAGE,HWY_KIT_OCC_HAULING_BIN_RENTAL,HWY_KIT_PPP_HAULING,HWY_KIT_RECYCLE_BC_TONNAGE,HWY_KIT_CESA_TONNES,HWY_KIT_EPRA_TONNES,HWY_KIT_LIGHT_RECYCLE_COUNTS,HWY_KIT_PAINT_RECYCLE_COUNTS,HWY_KIT_SCRAP_METAL_MARR_INCLUDED,HWY_KIT_LAB_TONNES,HWY_KIT_TIRE_COUNTS,HWY_KIT_TIRE_CHARGES,HWY_KIT_FREON_REMOVAL_CHARGES,HWY_KIT_RECYCLE_BC_INCOME,HWY_KIT_CESA_INCOME,HWY_KIT_EPRA_INCOME,HWY_KIT_LIGHT_RECYCLE_INCOME,HWY_KIT_PAINT_RECYCLE_INCOME,HWY_KIT_MARR_INCOME,HWY_KIT_LAB_INCOME,HWY_KIT_TOTAL_TONNES_EPR,HWY_KIT_NET_INCOME")] HWY37N_KITWANGA hWY37N_KITWANGA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hWY37N_KITWANGA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hWY37N_KITWANGA);
        }

        // GET: HWY37N_KITWANGA/Edit/5
        public async Task<IActionResult> Edit(DateTime? id)
        {
            if (id == null || _context.HWY37N_KITWANGA == null)
            {
                return NotFound();
            }

            var hWY37N_KITWANGA = await _context.HWY37N_KITWANGA.FindAsync(id);
            if (hWY37N_KITWANGA == null)
            {
                return NotFound();
            }
            return View(hWY37N_KITWANGA);
        }

        // POST: HWY37N_KITWANGA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DateTime id, [Bind("HWY_KIT_DATE,HWY_KIT_OCC_TONNAGE_EST,HWY_KIT_PPP_TONNAGE,HWY_KIT_OCC_HAULING_BIN_RENTAL,HWY_KIT_PPP_HAULING,HWY_KIT_RECYCLE_BC_TONNAGE,HWY_KIT_CESA_TONNES,HWY_KIT_EPRA_TONNES,HWY_KIT_LIGHT_RECYCLE_COUNTS,HWY_KIT_PAINT_RECYCLE_COUNTS,HWY_KIT_SCRAP_METAL_MARR_INCLUDED,HWY_KIT_LAB_TONNES,HWY_KIT_TIRE_COUNTS,HWY_KIT_TIRE_CHARGES,HWY_KIT_FREON_REMOVAL_CHARGES,HWY_KIT_RECYCLE_BC_INCOME,HWY_KIT_CESA_INCOME,HWY_KIT_EPRA_INCOME,HWY_KIT_LIGHT_RECYCLE_INCOME,HWY_KIT_PAINT_RECYCLE_INCOME,HWY_KIT_MARR_INCOME,HWY_KIT_LAB_INCOME,HWY_KIT_TOTAL_TONNES_EPR,HWY_KIT_NET_INCOME")] HWY37N_KITWANGA hWY37N_KITWANGA)
        {
            if (id != hWY37N_KITWANGA.HWY_KIT_DATE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hWY37N_KITWANGA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HWY37N_KITWANGAExists(hWY37N_KITWANGA.HWY_KIT_DATE))
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
            return View(hWY37N_KITWANGA);
        }

        // GET: HWY37N_KITWANGA/Delete/5
        public async Task<IActionResult> Delete(DateTime? id)
        {
            if (id == null || _context.HWY37N_KITWANGA == null)
            {
                return NotFound();
            }

            var hWY37N_KITWANGA = await _context.HWY37N_KITWANGA
                .FirstOrDefaultAsync(m => m.HWY_KIT_DATE == id);
            if (hWY37N_KITWANGA == null)
            {
                return NotFound();
            }

            return View(hWY37N_KITWANGA);
        }

        // POST: HWY37N_KITWANGA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime id)
        {
            if (_context.HWY37N_KITWANGA == null)
            {
                return Problem("Entity set 'RDKSDatabaseContext.HWY37N_KITWANGA'  is null.");
            }
            var hWY37N_KITWANGA = await _context.HWY37N_KITWANGA.FindAsync(id);
            if (hWY37N_KITWANGA != null)
            {
                _context.HWY37N_KITWANGA.Remove(hWY37N_KITWANGA);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HWY37N_KITWANGAExists(DateTime id)
        {
          return (_context.HWY37N_KITWANGA?.Any(e => e.HWY_KIT_DATE == id)).GetValueOrDefault();
        }
    }
}
