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
    public class Our_TeamController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; // Add this line

        public Our_TeamController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Our_Team
        public async Task<IActionResult> Index()
        {
              return _context.Our_Teams != null ? 
                          View(await _context.Our_Teams.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Our_Teams'  is null.");
        }

        // GET: Our_Team/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Our_Teams == null)
            {
                return NotFound();
            }

            var our_Team = await _context.Our_Teams
                .FirstOrDefaultAsync(m => m.Our_TeamId == id);
            if (our_Team == null)
            {
                return NotFound();
            }

            return View(our_Team);
        }

        // GET: Our_Team/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Our_Team/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Our_TeamId,Title,Description,Image")] Our_Team our_Team, IFormFile Image)
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
                    our_Team.Image = "/uploads/" + uniqueFileName; // Relative path to the image

                    _context.Add(our_Team);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(our_Team);
        }

        // GET: Our_Team/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Our_Teams == null)
            {
                return NotFound();
            }

            var our_Team = await _context.Our_Teams.FindAsync(id);
            if (our_Team == null)
            {
                return NotFound();
            }
            return View(our_Team);
        }

        // POST: Our_Team/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Our_TeamId,Title,Description,Image")] Our_Team our_Team, IFormFile Image)
        {
            if (id != our_Team.Our_TeamId)
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
                        our_Team.Image = "/uploads/" + uniqueFileName; // Relative path to the image
                    }
                    _context.Update(our_Team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Our_TeamExists(our_Team.Our_TeamId))
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
            return View(our_Team);
        }

        // GET: Our_Team/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Our_Teams == null)
            {
                return NotFound();
            }

            var our_Team = await _context.Our_Teams
                .FirstOrDefaultAsync(m => m.Our_TeamId == id);
            if (our_Team == null)
            {
                return NotFound();
            }

            return View(our_Team);
        }

        // POST: Our_Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Our_Teams == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Our_Teams'  is null.");
            }
            var our_Team = await _context.Our_Teams.FindAsync(id);
            if (our_Team != null)
            {
                _context.Our_Teams.Remove(our_Team);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Our_TeamExists(int id)
        {
          return (_context.Our_Teams?.Any(e => e.Our_TeamId == id)).GetValueOrDefault();
        }
    }
}
