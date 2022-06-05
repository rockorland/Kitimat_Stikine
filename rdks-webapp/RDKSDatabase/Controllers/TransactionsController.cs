using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RDKSDatabase.Data;
using RDKSDatabase.Models;
using RDKSDatabase.Models.ViewModels;

namespace RDKSDatabase.Controllers
{
    /// <summary>
    /// This class is Transaction model controller
    /// </summary>
    public class TransactionsController : Controller
    {
        private readonly RDKSDatabaseContext _context;

        public TransactionsController(RDKSDatabaseContext context)
        {
            _context = context;
        }
        // GET: Transactions
       /// <summary>
       /// The index page shows the transaction records in the database
       /// </summary>
       /// <param name="tranNum">The user input transanction number</param>
       /// <returns>All the transanction records if parameter if null, ohterwise return the record which transaction 
       /// number contains tranNum</returns>
        public async Task<IActionResult> Index(string? tranNum)
        {
            var transactions = from m in _context.Transaction select m;

            if (!String.IsNullOrEmpty(tranNum))
            {
                transactions = transactions.Where(x => x.TRANS_NUM.Contains(tranNum));
                return View(await transactions.ToListAsync());
            }
            else
            {
                return _context.Transaction != null ?
                                         View(await _context.Transaction.ToListAsync()) :
                                         Problem("Entity set 'RDKSDatabaseContext.Transaction'  is null.");
            }
        }

        // GET: Transactions/Details/5
        /// <summary>
        /// The details page shows all the attributes of a certain transaction and related record of customer informaiton
        /// </summary>
        /// <param name="id">The transaction number</param>
        /// <returns>Transaction attributes in view and related customer record</returns>
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Transaction == null)
            {
                return NotFound();
            }

            TransactionIndexData viewmodel = new TransactionIndexData();

            Transaction transaction = await _context.Transaction.FirstOrDefaultAsync(m => m.TRANS_NUM == id);
            Customer customer = await _context.Customer.FirstOrDefaultAsync(m => m.CUS_ID == transaction.CUS_ID);
            Vehicle vehicle = await _context.Vehicle.FirstOrDefaultAsync(m => m.LICENSE_PLATE == transaction.LICENSE_PLATE);

            viewmodel.Transaction = transaction;
            viewmodel.Customer = customer;
            viewmodel.Vehicle = vehicle;

            if (transaction == null)
            {
                return NotFound();
            }

            return View(viewmodel);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewData["CUS_ID"] = new SelectList(_context.Customer, "CUS_ID", "CUS_FNAME");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TRANS_NUM,CUS_ID,LICENSE_PLATE,TRANS_COMPLETION_DATE,TRANS_COMPLETION_TIME,TRANS_LOAD_NUM,TRANS_NETWEIGHT,TRANS_TOTALPRICE,TRANS_HAULER,TRANS_DRIVER_EXEMPT_STATUS,VALID_IMPORT_CODE,TRANS_CONTRACT,TRANS_OPERATION,TRANS_STATUS,TRANS_ISMANUAL,TRANS_HASEXCEPTION,TRANS_SOURCE_TYPE,TRANS_ADJUSTED_PRICE,TRANS_FACILITY_CODE,TRANS_TONNES,TRANS_CUBIC_METERS,TRANS_IN_SERVICE_AREA,TRANS_ASC_NON_ASC,TRANS_FUNCTION,TRANS_CURBSIDE_AREA,TRANS_CURBSIDE_STREAM,TRANS_ANNUAL_REPORTING_GROUP,TRANS_ANNUAL_REPORTING_SOURCE,TRANS_SERVICE_AREA")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CUS_ID"] = new SelectList(_context.Customer, "CUS_ID", "CUS_FNAME", transaction.CUS_ID);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Transaction == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            //ViewData["CUS_ID"] = new SelectList(_context.Customer, "CUS_ID", "CUS_FNAME", transaction.CUS_ID);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TRANS_NUM,CUS_ID,LICENSE_PLATE,TRANS_COMPLETION_DATE,TRANS_COMPLETION_TIME,TRANS_LOAD_NUM,TRANS_NETWEIGHT,TRANS_TOTALPRICE,TRANS_HAULER,TRANS_DRIVER_EXEMPT_STATUS,VALID_IMPORT_CODE,TRANS_CONTRACT,TRANS_OPERATION,TRANS_STATUS,TRANS_ISMANUAL,TRANS_HASEXCEPTION,TRANS_SOURCE_TYPE,TRANS_ADJUSTED_PRICE,TRANS_FACILITY_CODE,TRANS_TONNES,TRANS_CUBIC_METERS,TRANS_IN_SERVICE_AREA,TRANS_ASC_NON_ASC,TRANS_FUNCTION,TRANS_CURBSIDE_AREA,TRANS_CURBSIDE_STREAM,TRANS_ANNUAL_REPORTING_GROUP,TRANS_ANNUAL_REPORTING_SOURCE,TRANS_SERVICE_AREA")] Transaction transaction)
        {
            if (id != transaction.TRANS_NUM)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TRANS_NUM))
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
            //ViewData["CUS_ID"] = new SelectList(_context.Customer, "CUS_ID", "CUS_FNAME", transaction.CUS_ID);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Transaction == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Customer)
                .FirstOrDefaultAsync(m => m.TRANS_NUM == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Transaction == null)
            {
                return Problem("Entity set 'RDKSDatabaseContext.Transaction'  is null.");
            }
            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction != null)
            {
                _context.Transaction.Remove(transaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(string id)
        {
          return (_context.Transaction?.Any(e => e.TRANS_NUM == id)).GetValueOrDefault();
        }
    }
}
