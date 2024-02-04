using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Primis_Technical_Solutions.Data;
using Primis_Technical_Solutions.Models;

namespace Primis_Technical_Solutions.Controllers
{
    public class Contact_ReasonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Contact_ReasonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contact_Reason
        public async Task<IActionResult> Index()
        {
              return _context.Contact_Reasons != null ? 
                          View(await _context.Contact_Reasons.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Contact_Reasons'  is null.");
        }

        // GET: Contact_Reason/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contact_Reasons == null)
            {
                return NotFound();
            }

            var contact_Reason = await _context.Contact_Reasons
                .FirstOrDefaultAsync(m => m.Contact_ReasonId == id);
            if (contact_Reason == null)
            {
                return NotFound();
            }

            return View(contact_Reason);
        }

        // GET: Contact_Reason/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contact_Reason/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Contact_ReasonId,Reason_For_Contact")] Contact_Reason contact_Reason)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact_Reason);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact_Reason);
        }

        // GET: Contact_Reason/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contact_Reasons == null)
            {
                return NotFound();
            }

            var contact_Reason = await _context.Contact_Reasons.FindAsync(id);
            if (contact_Reason == null)
            {
                return NotFound();
            }
            return View(contact_Reason);
        }

        // POST: Contact_Reason/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Contact_ReasonId,Reason_For_Contact")] Contact_Reason contact_Reason)
        {
            if (id != contact_Reason.Contact_ReasonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact_Reason);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Contact_ReasonExists(contact_Reason.Contact_ReasonId))
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
            return View(contact_Reason);
        }

        // GET: Contact_Reason/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contact_Reasons == null)
            {
                return NotFound();
            }

            var contact_Reason = await _context.Contact_Reasons
                .FirstOrDefaultAsync(m => m.Contact_ReasonId == id);
            if (contact_Reason == null)
            {
                return NotFound();
            }

            return View(contact_Reason);
        }

        // POST: Contact_Reason/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contact_Reasons == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Contact_Reasons'  is null.");
            }
            var contact_Reason = await _context.Contact_Reasons.FindAsync(id);
            if (contact_Reason != null)
            {
                _context.Contact_Reasons.Remove(contact_Reason);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Contact_ReasonExists(int id)
        {
          return (_context.Contact_Reasons?.Any(e => e.Contact_ReasonId == id)).GetValueOrDefault();
        }
    }
}
