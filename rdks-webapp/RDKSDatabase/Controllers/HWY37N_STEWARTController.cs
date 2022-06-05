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
    /// The controller of HWY37N_STEWART.
    /// </summary>
    public class HWY37N_STEWARTController : Controller
    {
        private readonly RDKSDatabaseContext _context;

        public HWY37N_STEWARTController(RDKSDatabaseContext context)
        {
            _context = context;
        }

        // GET: HWY37N_STEWART
        public async Task<IActionResult> Index(string sortOrder, DateTime searchString1, DateTime searchString2)
        {
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter1"] = searchString1;
            ViewData["CurrentFilter2"] = searchString2;
            String defaultDate = "0001";

            var stewart = from ste in _context.HWY37N_STEWART
                               select ste;

            if (searchString1.ToString().Contains(defaultDate) || searchString2.ToString().Contains(defaultDate))
            {
                stewart = stewart.Select(x => x);
            }
            else
            {
                stewart = stewart.Where(ste => ste.HWY_STE_DATE >= searchString1 && ste.HWY_STE_DATE <= searchString2);
            }

            switch (sortOrder)
            {
                case "date_desc":
                    stewart = stewart.OrderByDescending(ste => ste.HWY_STE_DATE);
                    break;
                default:
                    stewart = stewart.OrderBy(ste => ste.HWY_STE_DATE);
                    break;
            }
            return View(await stewart.AsNoTracking().ToListAsync());
        }

        // GET: HWY37N_STEWART/Details/5
        public async Task<IActionResult> Details(DateTime? id)
        {
            if (id == null || _context.HWY37N_STEWART == null)
            {
                return NotFound();
            }

            var hWY37N_STEWART = await _context.HWY37N_STEWART
                .FirstOrDefaultAsync(m => m.HWY_STE_DATE == id);
            if (hWY37N_STEWART == null)
            {
                return NotFound();
            }

            return View(hWY37N_STEWART);
        }

        // GET: HWY37N_STEWART/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HWY37N_STEWART/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HWY_STE_DATE,HWY_STE_OCC_TONNES,HWY_STE_BANDSTRA_OCC_HAULING,HWY_STE_OCC_TOTAL,HWY_STE_RECYCLE_BC_TONNAGE,HWY_STE_CESA_TONNES,HWY_STE_EPRA_TONNES,HWY_STE_LIGHT_RECYCLE_COUNTS,HWY_STE_PAINT_RECYCLE_COUNTS,HWY_STE_SCRAP_METAL_MARR_TONNE_EST,HWY_STE_LAB_TONNES,HWY_STE_TIRE_COUNTS,HWY_STE_TIRE_CHARGES,HWY_STE_FREON_REMOVAL_CHARGES,HWY_STE_RECYCLE_BC_INCOME,HWY_STE_CESA_INCOME,HWY_STE_EPRA_INCOME,HWY_STE_LIGHT_RECYCLE_INCOME,HWY_STE_RECYCLE_INCOME,HWY_STE_MARR_INCOME,HWY_STE_LAB_INCOME,HWY_STE_TOTAL_TONNES_EPR,HWY_STE_NET_INCOME")] HWY37N_STEWART hWY37N_STEWART)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hWY37N_STEWART);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hWY37N_STEWART);
        }

        // GET: HWY37N_STEWART/Edit/5
        public async Task<IActionResult> Edit(DateTime? id)
        {
            if (id == null || _context.HWY37N_STEWART == null)
            {
                return NotFound();
            }

            var hWY37N_STEWART = await _context.HWY37N_STEWART.FindAsync(id);
            if (hWY37N_STEWART == null)
            {
                return NotFound();
            }
            return View(hWY37N_STEWART);
        }

        // POST: HWY37N_STEWART/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DateTime id, [Bind("HWY_STE_DATE,HWY_STE_OCC_TONNES,HWY_STE_BANDSTRA_OCC_HAULING,HWY_STE_OCC_TOTAL,HWY_STE_RECYCLE_BC_TONNAGE,HWY_STE_CESA_TONNES,HWY_STE_EPRA_TONNES,HWY_STE_LIGHT_RECYCLE_COUNTS,HWY_STE_PAINT_RECYCLE_COUNTS,HWY_STE_SCRAP_METAL_MARR_TONNE_EST,HWY_STE_LAB_TONNES,HWY_STE_TIRE_COUNTS,HWY_STE_TIRE_CHARGES,HWY_STE_FREON_REMOVAL_CHARGES,HWY_STE_RECYCLE_BC_INCOME,HWY_STE_CESA_INCOME,HWY_STE_EPRA_INCOME,HWY_STE_LIGHT_RECYCLE_INCOME,HWY_STE_RECYCLE_INCOME,HWY_STE_MARR_INCOME,HWY_STE_LAB_INCOME,HWY_STE_TOTAL_TONNES_EPR,HWY_STE_NET_INCOME")] HWY37N_STEWART hWY37N_STEWART)
        {
            if (id != hWY37N_STEWART.HWY_STE_DATE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hWY37N_STEWART);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HWY37N_STEWARTExists(hWY37N_STEWART.HWY_STE_DATE))
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
            return View(hWY37N_STEWART);
        }

        // GET: HWY37N_STEWART/Delete/5
        public async Task<IActionResult> Delete(DateTime? id)
        {
            if (id == null || _context.HWY37N_STEWART == null)
            {
                return NotFound();
            }

            var hWY37N_STEWART = await _context.HWY37N_STEWART
                .FirstOrDefaultAsync(m => m.HWY_STE_DATE == id);
            if (hWY37N_STEWART == null)
            {
                return NotFound();
            }

            return View(hWY37N_STEWART);
        }

        // POST: HWY37N_STEWART/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime id)
        {
            if (_context.HWY37N_STEWART == null)
            {
                return Problem("Entity set 'RDKSDatabaseContext.HWY37N_STEWART'  is null.");
            }
            var hWY37N_STEWART = await _context.HWY37N_STEWART.FindAsync(id);
            if (hWY37N_STEWART != null)
            {
                _context.HWY37N_STEWART.Remove(hWY37N_STEWART);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HWY37N_STEWARTExists(DateTime id)
        {
          return (_context.HWY37N_STEWART?.Any(e => e.HWY_STE_DATE == id)).GetValueOrDefault();
        }
    }
}
