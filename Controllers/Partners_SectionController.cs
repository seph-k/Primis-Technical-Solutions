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
    public class Partners_SectionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; // Add this line

        public Partners_SectionController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Partners_Section
        public async Task<IActionResult> Index()
        {
              return _context.Partners_Sections != null ? 
                          View(await _context.Partners_Sections.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Partners_Sections'  is null.");
        }

        // GET: Partners_Section/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Partners_Sections == null)
            {
                return NotFound();
            }

            var partners_Section = await _context.Partners_Sections
                .FirstOrDefaultAsync(m => m.Partners_SectionId == id);
            if (partners_Section == null)
            {
                return NotFound();
            }

            return View(partners_Section);
        }

        // GET: Partners_Section/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Partners_Section/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Partners_SectionId,Partner_Title,Partner_Icon")] Partners_Section partners_Section, IFormFile Partner_Icon)
        {
            if (ModelState.IsValid)
            {
                if (Partner_Icon != null && Partner_Icon.Length > 0)
                {
                    // Generate a unique file name for the image (you can customize this logic)
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Partner_Icon.FileName;

                    // Define the path to save the image in the wwwroot/uploads folder
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Create the uploads folder if it doesn't exist
                    Directory.CreateDirectory(uploadsFolder);

                    // Save the uploaded image to the file system
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Partner_Icon.CopyToAsync(stream);
                    }

                    // Save the image file path to the database
                    partners_Section.Partner_Icon = "/uploads/" + uniqueFileName; // Relative path to the image

                    _context.Add(partners_Section);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(partners_Section);
        }

        // GET: Partners_Section/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Partners_Sections == null)
            {
                return NotFound();
            }

            var partners_Section = await _context.Partners_Sections.FindAsync(id);
            if (partners_Section == null)
            {
                return NotFound();
            }
            return View(partners_Section);
        }

        // POST: Partners_Section/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Partners_SectionId,Partner_Title,Partner_Icon")] Partners_Section partners_Section, IFormFile Partner_Icon)
        {
            if (id != partners_Section.Partners_SectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Check if an image was uploaded
                    if (Partner_Icon != null && Partner_Icon.Length > 0)
                    {
                        // Generate a unique file name for the image (you can customize this logic)
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Partner_Icon.FileName;

                        // Define the path to save the image in the wwwroot/uploads folder
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        // Create the uploads folder if it doesn't exist
                        Directory.CreateDirectory(uploadsFolder);

                        // Save the uploaded image to the file system
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await Partner_Icon.CopyToAsync(stream);
                        }

                        // Save the image file path to the database
                        partners_Section.Partner_Icon = "/uploads/" + uniqueFileName; // Relative path to the image
                    }
                    _context.Update(partners_Section);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Partners_SectionExists(partners_Section.Partners_SectionId))
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
            return View(partners_Section);
        }

        // GET: Partners_Section/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Partners_Sections == null)
            {
                return NotFound();
            }

            var partners_Section = await _context.Partners_Sections
                .FirstOrDefaultAsync(m => m.Partners_SectionId == id);
            if (partners_Section == null)
            {
                return NotFound();
            }

            return View(partners_Section);
        }

        // POST: Partners_Section/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Partners_Sections == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Partners_Sections'  is null.");
            }
            var partners_Section = await _context.Partners_Sections.FindAsync(id);
            if (partners_Section != null)
            {
                _context.Partners_Sections.Remove(partners_Section);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Partners_SectionExists(int id)
        {
          return (_context.Partners_Sections?.Any(e => e.Partners_SectionId == id)).GetValueOrDefault();
        }
    }
}
