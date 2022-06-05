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
    /// <summary>
    /// This class is the controller for permit model
    /// </summary>
    public class PermitsController : Controller
    {
        private readonly RDKSDatabaseContext _context;

        public PermitsController(RDKSDatabaseContext context)
        {
            _context = context;
        }

        // GET: Permits
        public async Task<IActionResult> Index(string? sortOrder, string? search_prefix, string? search_facility)
        {

            ViewData["SortParm"] = sortOrder == "desc" ? "desc" : "ascending";
            ViewData["prefix"] = search_prefix;
            ViewData["facility"] = search_facility;

            var rDKSDatabaseContext = from permit in _context.Permit select permit;

            System.Diagnostics.Debug.WriteLine(search_prefix != null);
            System.Diagnostics.Debug.WriteLine(search_facility != null);

            if (search_prefix != null)
            {
                rDKSDatabaseContext = rDKSDatabaseContext.Where(p => p.PermitNumberPrefix.ToString().Contains(search_prefix));
            }
            if (search_facility != null)
            {
                rDKSDatabaseContext = rDKSDatabaseContext.Where(p => p.FacilityCode.Contains(search_facility));
            }

            switch (sortOrder)
            {
                case "desc":
                    rDKSDatabaseContext = rDKSDatabaseContext.OrderByDescending(permit => permit.PermitNumberPrefix);
                    break;
                default:
                    rDKSDatabaseContext = rDKSDatabaseContext.OrderBy(permit => permit.PermitNumberPrefix);
                    break;
            }

            return View(await rDKSDatabaseContext.AsNoTracking().ToListAsync());
        }

        // GET: Permits/Details/5
        public async Task<IActionResult> Details(int? prefix, int? id)
        {
            if (id == null || _context.Permit == null)
            {
                return NotFound();
            }

            var permit = await _context.Permit.FindAsync(prefix, id);
     
            if (permit == null)
            {
                return NotFound();
            }

            return View(permit);
        }

        // GET: Permits/Create
        public IActionResult Create()
        {
            ViewData["MaterialCode"] = new SelectList(_context.Set<Material>(), "MaterialCode", "MaterialType");
            return View();
        }

        // POST: Permits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PermitNumberPrefix,PermitNumber,FacilityCode,PermitApplicationDate,EstimatedVolume,units,EstimatedLoads,Frequency,Comments,ContaminateLoadsDate,ContaminateLoadsComments,ContaminatedLoads,PermitSentToOperatorAndWMF,PermitSavedOnServerAndFiled,HardCopyPermitSavedInFile,ApprovedBy,PermitClosedCardPermissionsRevolked,PermitStatus,PermitType,PermitFee,ExpirationDate,ApplicationFeeInvoiced,ApplicantName,ApplicantPhone,ApplicantEmail,Hauler,Hauler2,CUS_ID,WasteGenerator,MaterialCode")] Permit permit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaterialCode"] = new SelectList(_context.Set<Material>(), "MaterialCode", "MaterialType", permit.MaterialCode);
            return View(permit);
        }

        // GET: Permits/Edit/5
        public async Task<IActionResult> Edit(int? prefix, int? id)
        {
            if (id == null || _context.Permit == null)
            {
                return NotFound();
            }

            var permit = await _context.Permit.FindAsync(prefix, id);

            if (permit == null)
            {
                return NotFound();
            }
            ViewData["MaterialCode"] = new SelectList(_context.Set<Material>(), "MaterialCode", "MaterialType", permit.MaterialCode);
            return View(permit);
        }

        // POST: Permits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int prefix, int id, [Bind("PermitNumberPrefix,PermitNumber,FacilityCode,PermitApplicationDate,EstimatedVolume,units,EstimatedLoads,Frequency,Comments,ContaminateLoadsDate,ContaminateLoadsComments,ContaminatedLoads,PermitSentToOperatorAndWMF,PermitSavedOnServerAndFiled,HardCopyPermitSavedInFile,ApprovedBy,PermitClosedCardPermissionsRevolked,PermitStatus,PermitType,PermitFee,ExpirationDate,ApplicationFeeInvoiced,ApplicantName,ApplicantPhone,ApplicantEmail,Hauler,Hauler2,CUS_ID,WasteGenerator,MaterialCode")] Permit permit)
        {
            if (permit.PermitNumberPrefix != prefix || permit.PermitNumber != id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermitExists(prefix, id))
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
            ViewData["MaterialCode"] = new SelectList(_context.Set<Material>(), "MaterialCode", "MaterialType", permit.MaterialCode);
            return View(permit);
        }

        // GET: Permits/Delete/5
        public async Task<IActionResult> Delete(int prefix, int id)
        {
            if (id.Equals(null) || _context.Permit == null)
            {
                return NotFound();
            }

            var permit = await _context.Permit.FindAsync(prefix, id);

            if (permit == null)
            {
                return NotFound();
            }

            return View(permit);
        }

        // POST: Permits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int prefix, int id)
        {
            if (_context.Permit == null)
            {
                return Problem("Entity set 'RDKSDatabaseContext.Permit'  is null.");
            }
            var permit = await _context.Permit.FindAsync(prefix, id);

            if (permit != null)
            {
                _context.Permit.Remove(permit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermitExists(int prefix, int id)
        {
          return (_context.Permit?.Find(prefix, id).Equals(null)).GetValueOrDefault();
        }
    }
}
