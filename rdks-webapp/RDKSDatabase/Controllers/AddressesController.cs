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
    public class AddressesController : Controller
    {
        private readonly RDKSDatabaseContext _context;

        public AddressesController(RDKSDatabaseContext context)
        {
            _context = context;
        }

        // GET: Addresses
        public async Task<IActionResult> Index(string sortOrder, string searchString1, string searchString2)
        {

            ViewData["CurrentFilter1"] = searchString1;
            ViewData["CurrentFilter2"] = searchString2;

            var address = from addr in _context.Address
                           select addr;
            if (!String.IsNullOrEmpty(searchString1) && String.IsNullOrEmpty(searchString2))
            {
                address = address.Where(addr => addr.ADDR_CITY.Contains(searchString1));
            }
            if (String.IsNullOrEmpty(searchString1) && !String.IsNullOrEmpty(searchString2))
            {
                address = address.Where(addr => addr.ADDR_PROV.Contains(searchString2));
            }
            if (!String.IsNullOrEmpty(searchString1) && !String.IsNullOrEmpty(searchString2))
            {
                address = address.Where(addr => addr.ADDR_CITY.Contains(searchString1) && addr.ADDR_PROV.Contains(searchString2));
            }

            return View(await address.AsNoTracking().ToListAsync());
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Address == null)
            {
                return NotFound();
            }

            var address = await _context.Address
                .FirstOrDefaultAsync(m => m.ADDR_ID == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ADDR_ID,ADDR_STREET,ADDR_CITY,ADDR_PROV,ADDR_POCODE,CUS_ID")] Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Add(address);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(address);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Address == null)
            {
                return NotFound();
            }

            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ADDR_ID,ADDR_STREET,ADDR_CITY,ADDR_PROV,ADDR_POCODE,CUS_ID")] Address address)
        {
            if (id != address.ADDR_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.ADDR_ID))
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
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Address == null)
            {
                return NotFound();
            }

            var address = await _context.Address
                .FirstOrDefaultAsync(m => m.ADDR_ID == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Address == null)
            {
                return Problem("Entity set 'RDKSDatabaseContext.Address'  is null.");
            }
            var address = await _context.Address.FindAsync(id);
            if (address != null)
            {
                _context.Address.Remove(address);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(int id)
        {
          return (_context.Address?.Any(e => e.ADDR_ID == id)).GetValueOrDefault();
        }
    }
}
