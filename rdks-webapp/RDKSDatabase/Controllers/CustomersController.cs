using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RDKSDatabase.Data;
using RDKSDatabase.Models;
using RDKSDatabase.ViewModels;

namespace RDKSDatabase.Controllers
{
    public class CustomersController : Controller
    {
        private readonly RDKSDatabaseContext _context;

        public CustomersController(RDKSDatabaseContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return _context.Customer != null ?
                      View(await _context.Customer.ToListAsync()) :
                      Problem("Entity set 'RDKSDatabaseContext.Customer'  is null.");
        }

        /// <summary>
        /// Search controller to search for customer rows and related tables using a view model
        /// </summary>
        /// <param name="cus_accnum">Customer account number to search for</param>
        /// <param name="cus_compname">Customer company name to search for</param>
        /// <returns></returns>
        public async Task<IActionResult> Search(string? cus_accnum, string? cus_compname)
        {
            ViewData["cus_accnum"] = cus_accnum;
            ViewData["cus_compname"] = cus_compname;

            var viewModel = new CustomerInfo();
            viewModel.Customers = await _context.Customer
                  .AsNoTracking()
                  .OrderBy(c => c.CUS_COMPNAME)
                  .ToListAsync();

            var customers = from customer in _context.Customer
                            select customer;
            try
            {
                ViewData["recordFound"] = viewModel.Results.Any();
            }
            catch (ArgumentNullException)
            {
                ViewData["recordFound"] = false;
            }
     
            if (cus_accnum != null)
            {
                customers = customers.Where(c => c.CUS_ACCNUM.Contains(cus_accnum));

                try
                {
                    ViewData["recordFound"] = customers.Any();
                }
                catch (ArgumentNullException)
                {
                    ViewData["recordFound"] = false;
                }

                if (ViewData["recordFound"].Equals(true))
                {
                    viewModel.Results = await customers
                        .AsNoTracking()
                        .OrderBy(c => c.CUS_COMPNAME)
                        .ToListAsync();
                }
            }
            if (cus_compname != null)
            {
                customers = customers.Where(c => c.CUS_COMPNAME.Contains(cus_compname));

                try
                {
                    ViewData["recordFound"] = customers.Any();
                }
                catch (ArgumentNullException)
                {
                    ViewData["recordFound"] = false;
                }

                if (ViewData["recordFound"].Equals(true))
                {
                    viewModel.Results = await customers
                        .AsNoTracking()
                        .OrderBy(c => c.CUS_COMPNAME)
                        .ToListAsync();
                }
            }

            return View(viewModel);
        }


        public async Task<IActionResult> InfoPage(int? id)
        {
            var viewModel = new CustomerInfo();
            viewModel.SelectedCustomer = await _context.Customer
                .SingleAsync(c => c.CUS_ID.Equals(id));
            viewModel.Addresses = await _context.Address
                .Where(a => a.CUS_ID.Equals(id))
                .AsNoTracking()
                .ToListAsync();
            viewModel.Permits = await _context.Permit
                .Where(p => p.CUS_ID.Equals(id))
                .AsNoTracking()
                .ToListAsync();
            viewModel.Vehicles = await _context.Vehicle
                .Where(v => v.CUS_ID.Equals(id))
                .AsNoTracking()
                .ToListAsync();

            return View(viewModel);
        }


        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CUS_ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CUS_ID,CUS_ACCNUM,CUS_COMPNAME,CUS_FNAME,CUS_LNAME,CUS_PHONE,CUS_ALT_PHONE,CUS_EMAIL,CUS_ALT_EMAIL,CUS_FR,CUS_TTS,CUS_MEZ,CUS_DEACTIVATED_COUNT,CUS_NOTE")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CUS_ID,CUS_ACCNUM,CUS_COMPNAME,CUS_FNAME,CUS_LNAME,CUS_PHONE,CUS_ALT_PHONE,CUS_EMAIL,CUS_ALT_EMAIL,CUS_FR,CUS_TTS,CUS_MEZ,CUS_DEACTIVATED_COUNT,CUS_NOTE")] Customer customer)
        {
            if (id != customer.CUS_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CUS_ID))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CUS_ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set 'RDKSDatabaseContext.Customer'  is null.");
            }
            var customer = await _context.Customer.FindAsync(id);
            if (customer != null)
            {
                _context.Customer.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
          return (_context.Customer?.Any(e => e.CUS_ID == id)).GetValueOrDefault();
        }
    }
}
