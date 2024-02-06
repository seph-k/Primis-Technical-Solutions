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
    public class Banners_LogoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; // Add this line

        public Banners_LogoController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Banners_Logo
        public async Task<IActionResult> Index()
        {
              return _context.Banners_Logos != null ? 
                          View(await _context.Banners_Logos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Banners_Logos'  is null.");
        }

        // GET: Banners_Logo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Banners_Logos == null)
            {
                return NotFound();
            }

            var banners_Logo = await _context.Banners_Logos
                .FirstOrDefaultAsync(m => m.Banners_LogoId == id);
            if (banners_Logo == null)
            {
                return NotFound();
            }

            return View(banners_Logo);
        }

        private async Task<string> SaveImage(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                // Generate a unique file name for the image (you can customize this logic)
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                // Define the path to save the image in the wwwroot/uploads folder
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Create the uploads folder if it doesn't exist
                Directory.CreateDirectory(uploadsFolder);

                // Save the uploaded image to the file system
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Save the image file path to the database
                var relativePath = "/uploads/" + uniqueFileName; // Relative path to the image

                return relativePath; // Return the relative path
            }

            return null; // No file uploaded
        }


        // GET: Banners_Logo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banners_Logo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Banners_LogoId,Top_Logo,Bottom_Logo,About_Banner,Contact_Banner,Service_Banner,Table_Banner")] Banners_Logo banners_Logo, IFormFile Top_Logo, IFormFile Bottom_Logo, IFormFile About_Banner, IFormFile Contact_Banner, IFormFile Service_Banner, IFormFile Table_Banner)
        {
            if (ModelState.IsValid)
            {
                // Save the uploaded images
                banners_Logo.Top_Logo = await SaveImage(Top_Logo);
                banners_Logo.Bottom_Logo = await SaveImage(Bottom_Logo);
                banners_Logo.About_Banner = await SaveImage(About_Banner);
                banners_Logo.Contact_Banner = await SaveImage(Contact_Banner);
                banners_Logo.Service_Banner = await SaveImage(Service_Banner);
                banners_Logo.Table_Banner = await SaveImage(Table_Banner);


                _context.Add(banners_Logo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banners_Logo);
        }

        // GET: Banners_Logo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Banners_Logos == null)
            {
                return NotFound();
            }

            var banners_Logo = await _context.Banners_Logos.FindAsync(id);
            if (banners_Logo == null)
            {
                return NotFound();
            }
            return View(banners_Logo);
        }

        // POST: Banners_Logo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Banners_LogoId,Top_Logo,Bottom_Logo,About_Banner,Contact_Banner,Service_Banner,Table_Banner")] Banners_Logo banners_Logo, IFormFile Top_Logo, IFormFile Bottom_Logo, IFormFile About_Banner, IFormFile Contact_Banner, IFormFile Service_Banner, IFormFile Table_Banner)
        {
            if (id != banners_Logo.Banners_LogoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Save the uploaded images
                    banners_Logo.Top_Logo = await SaveImage(Top_Logo);
                    banners_Logo.Bottom_Logo = await SaveImage(Bottom_Logo);
                    banners_Logo.About_Banner = await SaveImage(About_Banner);
                    banners_Logo.Contact_Banner = await SaveImage(Contact_Banner);
                    banners_Logo.Service_Banner = await SaveImage(Service_Banner);
                    banners_Logo.Table_Banner = await SaveImage(Table_Banner);

                    _context.Update(banners_Logo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Banners_LogoExists(banners_Logo.Banners_LogoId))
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
            return View(banners_Logo);
        }

        // GET: Banners_Logo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Banners_Logos == null)
            {
                return NotFound();
            }

            var banners_Logo = await _context.Banners_Logos
                .FirstOrDefaultAsync(m => m.Banners_LogoId == id);
            if (banners_Logo == null)
            {
                return NotFound();
            }

            return View(banners_Logo);
        }

        // POST: Banners_Logo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Banners_Logos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Banners_Logos'  is null.");
            }
            var banners_Logo = await _context.Banners_Logos.FindAsync(id);
            if (banners_Logo != null)
            {
                _context.Banners_Logos.Remove(banners_Logo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Banners_LogoExists(int id)
        {
          return (_context.Banners_Logos?.Any(e => e.Banners_LogoId == id)).GetValueOrDefault();
        }
    }
}
