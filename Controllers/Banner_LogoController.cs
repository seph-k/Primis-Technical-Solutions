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
    public class Banner_LogoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; // Add this line

        public Banner_LogoController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Banner_Logo
        public async Task<IActionResult> Index()
        {
              return _context.Banner_Logos != null ? 
                          View(await _context.Banner_Logos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Banner_Logos'  is null.");
        }

        // GET: Banner_Logo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Banner_Logos == null)
            {
                return NotFound();
            }

            var banner_Logo = await _context.Banner_Logos
                .FirstOrDefaultAsync(m => m.Banner_LogoId == id);
            if (banner_Logo == null)
            {
                return NotFound();
            }

            return View(banner_Logo);
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

        // GET: Banner_Logo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banner_Logo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Banner_LogoId,Top_Logo,Bottom_Logo,About_Banner,Contact_Banner,Service_Banner,Table_Banner")] Banner_Logo banner_Logo, IFormFile Top_Logo, IFormFile Bottom_Logo, IFormFile About_Banner, IFormFile Contact_Banner, IFormFile Service_Banner, IFormFile Table_Banner)
        {
            if (ModelState.IsValid)
            {
                // Save the uploaded images
                banner_Logo.Top_Logo = await SaveImage(Top_Logo);
                banner_Logo.Bottom_Logo = await SaveImage(Bottom_Logo);
                banner_Logo.About_Banner = await SaveImage(About_Banner);
                banner_Logo.Contact_Banner = await SaveImage(Contact_Banner);
                banner_Logo.Service_Banner = await SaveImage(Service_Banner);
                banner_Logo.Table_Banner = await SaveImage(Table_Banner);

                _context.Add(banner_Logo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banner_Logo);
        }

        // GET: Banner_Logo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Banner_Logos == null)
            {
                return NotFound();
            }

            var banner_Logo = await _context.Banner_Logos.FindAsync(id);
            if (banner_Logo == null)
            {
                return NotFound();
            }
            return View(banner_Logo);
        }

        // POST: Banner_Logo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Banner_LogoId,Top_Logo,Bottom_Logo,About_Banner,Contact_Banner,Service_Banner,Table_Banner")] Banner_Logo banner_Logo, IFormFile Top_Logo, IFormFile Bottom_Logo, IFormFile About_Banner, IFormFile Contact_Banner, IFormFile Service_Banner, IFormFile Table_Banner)
        {
            if (id != banner_Logo.Banner_LogoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Save the uploaded images
                    banner_Logo.Top_Logo = await SaveImage(Top_Logo);
                    banner_Logo.Bottom_Logo = await SaveImage(Bottom_Logo);
                    banner_Logo.About_Banner = await SaveImage(About_Banner);
                    banner_Logo.Contact_Banner = await SaveImage(Contact_Banner);
                    banner_Logo.Service_Banner = await SaveImage(Service_Banner);
                    banner_Logo.Table_Banner = await SaveImage(Table_Banner);

                    _context.Update(banner_Logo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Banner_LogoExists(banner_Logo.Banner_LogoId))
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
            return View(banner_Logo);
        }

        // GET: Banner_Logo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Banner_Logos == null)
            {
                return NotFound();
            }

            var banner_Logo = await _context.Banner_Logos
                .FirstOrDefaultAsync(m => m.Banner_LogoId == id);
            if (banner_Logo == null)
            {
                return NotFound();
            }

            return View(banner_Logo);
        }

        // POST: Banner_Logo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Banner_Logos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Banner_Logos'  is null.");
            }
            var banner_Logo = await _context.Banner_Logos.FindAsync(id);
            if (banner_Logo != null)
            {
                _context.Banner_Logos.Remove(banner_Logo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Banner_LogoExists(int id)
        {
          return (_context.Banner_Logos?.Any(e => e.Banner_LogoId == id)).GetValueOrDefault();
        }
    }
}
