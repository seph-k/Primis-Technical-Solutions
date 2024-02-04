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
    public class Our_FeatureController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; // Add this line

        public Our_FeatureController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Our_Feature
        public async Task<IActionResult> Index()
        {
              return _context.Our_Features != null ? 
                          View(await _context.Our_Features.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Our_Features'  is null.");
        }

        // GET: Our_Feature/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Our_Features == null)
            {
                return NotFound();
            }

            var our_Feature = await _context.Our_Features
                .FirstOrDefaultAsync(m => m.Our_FeatureId == id);
            if (our_Feature == null)
            {
                return NotFound();
            }

            return View(our_Feature);
        }

        // GET: Our_Feature/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Our_Feature/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Our_FeatureId,Title,Description,Image")] Our_Feature our_Feature, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                // Check if an image was uploaded
                if (Image != null && Image.Length > 0)
                {
                    // Generate a unique file name for the image (you can customize this logic)
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;

                    // Define the path to save the image in the wwwroot/uploads folder
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Create the uploads folder if it doesn't exist
                    Directory.CreateDirectory(uploadsFolder);

                    // Save the uploaded image to the file system
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);
                    }

                    // Save the image file path to the database
                    our_Feature.Image = "/uploads/" + uniqueFileName; // Relative path to the image

                    _context.Add(our_Feature);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(our_Feature);
        }

        // GET: Our_Feature/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Our_Features == null)
            {
                return NotFound();
            }

            var our_Feature = await _context.Our_Features.FindAsync(id);
            if (our_Feature == null)
            {
                return NotFound();
            }
            return View(our_Feature);
        }

        // POST: Our_Feature/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Our_FeatureId,Title,Description,Image")] Our_Feature our_Feature, IFormFile Image)
        {
            if (id != our_Feature.Our_FeatureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Check if an image was uploaded
                    if (Image != null && Image.Length > 0)
                    {
                        // Generate a unique file name for the image (you can customize this logic)
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;

                        // Define the path to save the image in the wwwroot/uploads folder
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        // Create the uploads folder if it doesn't exist
                        Directory.CreateDirectory(uploadsFolder);

                        // Save the uploaded image to the file system
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await Image.CopyToAsync(stream);
                        }

                        // Save the image file path to the database
                        our_Feature.Image = "/uploads/" + uniqueFileName; // Relative path to the image
                    }
                    _context.Update(our_Feature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Our_FeatureExists(our_Feature.Our_FeatureId))
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
            return View(our_Feature);
        }

        // GET: Our_Feature/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Our_Features == null)
            {
                return NotFound();
            }

            var our_Feature = await _context.Our_Features
                .FirstOrDefaultAsync(m => m.Our_FeatureId == id);
            if (our_Feature == null)
            {
                return NotFound();
            }

            return View(our_Feature);
        }

        // POST: Our_Feature/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Our_Features == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Our_Features'  is null.");
            }
            var our_Feature = await _context.Our_Features.FindAsync(id);
            if (our_Feature != null)
            {
                _context.Our_Features.Remove(our_Feature);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Our_FeatureExists(int id)
        {
          return (_context.Our_Features?.Any(e => e.Our_FeatureId == id)).GetValueOrDefault();
        }
    }
}
