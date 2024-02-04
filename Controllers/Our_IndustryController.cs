using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Primis_Technical_Solutions.Data;
using Primis_Technical_Solutions.Models;

namespace Primis_Technical_Solutions.Controllers
{
    public class Our_IndustryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; // Add this line

        public Our_IndustryController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Our_Industry
        public async Task<IActionResult> Index()
        {
              return _context.Our_Industries != null ? 
                          View(await _context.Our_Industries.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Our_Industries'  is null.");
        }

        // GET: Our_Industry/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Our_Industries == null)
            {
                return NotFound();
            }

            var our_Industry = await _context.Our_Industries
                .FirstOrDefaultAsync(m => m.Our_IndustryId == id);
            if (our_Industry == null)
            {
                return NotFound();
            }

            return View(our_Industry);
        }

        // GET: Our_Industry/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Our_Industry/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Our_IndustryId,Industry_Title,Indutry_Icon")] Our_Industry our_Industry, IFormFile Indutry_Icon)
        {
            if (ModelState.IsValid)
            {
                // Check if an image was uploaded
                if (Indutry_Icon != null && Indutry_Icon.Length > 0)
                {
                    // Generate a unique file name for the image (you can customize this logic)
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Indutry_Icon.FileName;

                    // Define the path to save the image in the wwwroot/uploads folder
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Create the uploads folder if it doesn't exist
                    Directory.CreateDirectory(uploadsFolder);

                    // Save the uploaded image to the file system
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Indutry_Icon.CopyToAsync(stream);
                    }

                    // Save the image file path to the database
                    our_Industry.Indutry_Icon = "/uploads/" + uniqueFileName; // Relative path to the image

                    _context.Add(our_Industry);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(our_Industry);
        }

        // GET: Our_Industry/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Our_Industries == null)
            {
                return NotFound();
            }

            var our_Industry = await _context.Our_Industries.FindAsync(id);
            if (our_Industry == null)
            {
                return NotFound();
            }
            return View(our_Industry);
        }

        // POST: Our_Industry/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Our_IndustryId,Industry_Title,Indutry_Icon")] Our_Industry our_Industry, IFormFile Indutry_Icon)
        {
            if (id != our_Industry.Our_IndustryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Check if an image was uploaded
                    if (Indutry_Icon != null && Indutry_Icon.Length > 0)
                    {
                        // Generate a unique file name for the image (you can customize this logic)
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Indutry_Icon.FileName;

                        // Define the path to save the image in the wwwroot/uploads folder
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        // Create the uploads folder if it doesn't exist
                        Directory.CreateDirectory(uploadsFolder);

                        // Save the uploaded image to the file system
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await Indutry_Icon.CopyToAsync(stream);
                        }

                        // Save the image file path to the database
                        our_Industry.Indutry_Icon = "/uploads/" + uniqueFileName; // Relative path to the image
                    }
                    _context.Update(our_Industry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Our_IndustryExists(our_Industry.Our_IndustryId))
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
            return View(our_Industry);
        }

        // GET: Our_Industry/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Our_Industries == null)
            {
                return NotFound();
            }

            var our_Industry = await _context.Our_Industries
                .FirstOrDefaultAsync(m => m.Our_IndustryId == id);
            if (our_Industry == null)
            {
                return NotFound();
            }

            return View(our_Industry);
        }

        // POST: Our_Industry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Our_Industries == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Our_Industries'  is null.");
            }
            var our_Industry = await _context.Our_Industries.FindAsync(id);
            if (our_Industry != null)
            {
                _context.Our_Industries.Remove(our_Industry);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Our_IndustryExists(int id)
        {
          return (_context.Our_Industries?.Any(e => e.Our_IndustryId == id)).GetValueOrDefault();
        }
    }
}
