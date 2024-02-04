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
    public class Introductory_ContentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Introductory_ContentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Introductory_Content
        public async Task<IActionResult> Index()
        {
              return _context.Introductory_Contents != null ? 
                          View(await _context.Introductory_Contents.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Introductory_Contents'  is null.");
        }

        // GET: Introductory_Content/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Introductory_Contents == null)
            {
                return NotFound();
            }

            var introductory_Content = await _context.Introductory_Contents
                .FirstOrDefaultAsync(m => m.Introductory_ContentId == id);
            if (introductory_Content == null)
            {
                return NotFound();
            }

            return View(introductory_Content);
        }

        // GET: Introductory_Content/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Introductory_Content/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Introductory_ContentId,Home_Title,Home_Description,About_Title,About_Description,Contact_Title,Contact_Description")] Introductory_Content introductory_Content)
        {
            if (ModelState.IsValid)
            {
                _context.Add(introductory_Content);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(introductory_Content);
        }

        // GET: Introductory_Content/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Introductory_Contents == null)
            {
                return NotFound();
            }

            var introductory_Content = await _context.Introductory_Contents.FindAsync(id);
            if (introductory_Content == null)
            {
                return NotFound();
            }
            return View(introductory_Content);
        }

        // POST: Introductory_Content/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Introductory_ContentId,Home_Title,Home_Description,About_Title,About_Description,Contact_Title,Contact_Description")] Introductory_Content introductory_Content)
        {
            if (id != introductory_Content.Introductory_ContentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(introductory_Content);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Introductory_ContentExists(introductory_Content.Introductory_ContentId))
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
            return View(introductory_Content);
        }

        // GET: Introductory_Content/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Introductory_Contents == null)
            {
                return NotFound();
            }

            var introductory_Content = await _context.Introductory_Contents
                .FirstOrDefaultAsync(m => m.Introductory_ContentId == id);
            if (introductory_Content == null)
            {
                return NotFound();
            }

            return View(introductory_Content);
        }

        // POST: Introductory_Content/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Introductory_Contents == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Introductory_Contents'  is null.");
            }
            var introductory_Content = await _context.Introductory_Contents.FindAsync(id);
            if (introductory_Content != null)
            {
                _context.Introductory_Contents.Remove(introductory_Content);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Introductory_ContentExists(int id)
        {
          return (_context.Introductory_Contents?.Any(e => e.Introductory_ContentId == id)).GetValueOrDefault();
        }
    }
}
