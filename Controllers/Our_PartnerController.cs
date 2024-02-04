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
    public class Our_PartnerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; // Add this line

        public Our_PartnerController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Our_Partner
        public async Task<IActionResult> Index()
        {
              return _context.Our_Partners != null ? 
                          View(await _context.Our_Partners.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Our_Partners'  is null.");
        }

        // GET: Our_Partner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Our_Partners == null)
            {
                return NotFound();
            }

            var our_Partner = await _context.Our_Partners
                .FirstOrDefaultAsync(m => m.Our_PartnerId == id);
            if (our_Partner == null)
            {
                return NotFound();
            }

            return View(our_Partner);
        }

        // GET: Our_Partner/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Our_Partner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Our_PartnerId,Partner_Title,Partner_Description,Partner_Image")] Our_Partner our_Partner, IFormFile Partner_Image)
        {
            if (ModelState.IsValid)
            {
                // Check if an image was uploaded
                if (Partner_Image != null && Partner_Image.Length > 0)
                {
                    // Generate a unique file name for the image (you can customize this logic)
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Partner_Image.FileName;

                    // Define the path to save the image in the wwwroot/uploads folder
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Create the uploads folder if it doesn't exist
                    Directory.CreateDirectory(uploadsFolder);

                    // Save the uploaded image to the file system
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Partner_Image.CopyToAsync(stream);
                    }

                    // Save the image file path to the database
                    our_Partner.Partner_Image = "/uploads/" + uniqueFileName; // Relative path to the image

                    _context.Add(our_Partner);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(our_Partner);
        }

        // GET: Our_Partner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Our_Partners == null)
            {
                return NotFound();
            }

            var our_Partner = await _context.Our_Partners.FindAsync(id);
            if (our_Partner == null)
            {
                return NotFound();
            }
            return View(our_Partner);
        }

        // POST: Our_Partner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Our_PartnerId,Partner_Title,Partner_Description,Partner_Image")] Our_Partner our_Partner, IFormFile Partner_Image)
        {
            if (id != our_Partner.Our_PartnerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Check if an image was uploaded
                    if (Partner_Image != null && Partner_Image.Length > 0)
                    {
                        // Generate a unique file name for the image (you can customize this logic)
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Partner_Image.FileName;

                        // Define the path to save the image in the wwwroot/uploads folder
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        // Create the uploads folder if it doesn't exist
                        Directory.CreateDirectory(uploadsFolder);

                        // Save the uploaded image to the file system
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await Partner_Image.CopyToAsync(stream);
                        }

                        // Save the image file path to the database
                        our_Partner.Partner_Image = "/uploads/" + uniqueFileName; // Relative path to the image
                    }
                    _context.Update(our_Partner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Our_PartnerExists(our_Partner.Our_PartnerId))
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
            return View(our_Partner);
        }

        // GET: Our_Partner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Our_Partners == null)
            {
                return NotFound();
            }

            var our_Partner = await _context.Our_Partners
                .FirstOrDefaultAsync(m => m.Our_PartnerId == id);
            if (our_Partner == null)
            {
                return NotFound();
            }

            return View(our_Partner);
        }

        // POST: Our_Partner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Our_Partners == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Our_Partners'  is null.");
            }
            var our_Partner = await _context.Our_Partners.FindAsync(id);
            if (our_Partner != null)
            {
                _context.Our_Partners.Remove(our_Partner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Our_PartnerExists(int id)
        {
          return (_context.Our_Partners?.Any(e => e.Our_PartnerId == id)).GetValueOrDefault();
        }
    }
}
