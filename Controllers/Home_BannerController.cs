using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Primis_Technical_Solutions.Data;
using Primis_Technical_Solutions.Models;

namespace Primis_Technical_Solutions.Controllers
{
    public class Home_BannerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; // Add this line

        public Home_BannerController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Home_Banner
        public async Task<IActionResult> Index()
        {
              return _context.Home_Banners != null ? 
                          View(await _context.Home_Banners.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Home_Banners'  is null.");
        }

        // GET: Home_Banner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Home_Banners == null)
            {
                return NotFound();
            }

            var home_Banner = await _context.Home_Banners
                .FirstOrDefaultAsync(m => m.Home_BannerId == id);
            if (home_Banner == null)
            {
                return NotFound();
            }

            return View(home_Banner);
        }

        // GET: Home_Banner/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home_Banner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Home_BannerId,Title,Description,Image,mobileTitle,mobileDescription")] Home_Banner home_Banner, IFormFile Image)
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
                    home_Banner.Image = "/uploads/" + uniqueFileName; // Relative path to the image
                    
                    _context.Add(home_Banner);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(home_Banner);
        }

        // GET: Home_Banner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Home_Banners == null)
            {
                return NotFound();
            }

            var home_Banner = await _context.Home_Banners.FindAsync(id);
            if (home_Banner == null)
            {
                return NotFound();
            }
            return View(home_Banner);
        }

        // POST: Home_Banner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Home_BannerId,Title,Description,Image,mobileTitle,mobileDescription")] Home_Banner home_Banner, IFormFile Image)
        {
            if (id != home_Banner.Home_BannerId)
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
                        home_Banner.Image = "/uploads/" + uniqueFileName; // Relative path to the image
                    }
                    _context.Update(home_Banner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Home_BannerExists(home_Banner.Home_BannerId))
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
            return View(home_Banner);
        }

        // GET: Home_Banner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Home_Banners == null)
            {
                return NotFound();
            }

            var home_Banner = await _context.Home_Banners
                .FirstOrDefaultAsync(m => m.Home_BannerId == id);
            if (home_Banner == null)
            {
                return NotFound();
            }

            return View(home_Banner);
        }

        // POST: Home_Banner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Home_Banners == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Home_Banners'  is null.");
            }
            var home_Banner = await _context.Home_Banners.FindAsync(id);
            if (home_Banner != null)
            {
                _context.Home_Banners.Remove(home_Banner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Home_BannerExists(int id)
        {
          return (_context.Home_Banners?.Any(e => e.Home_BannerId == id)).GetValueOrDefault();
        }
    }
}
