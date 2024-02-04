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
    public class Our_SkillController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; // Add this line

        public Our_SkillController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Our_Skill
        public async Task<IActionResult> Index()
        {
              return _context.Our_Skills != null ? 
                          View(await _context.Our_Skills.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Our_Skills'  is null.");
        }

        // GET: Our_Skill/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Our_Skills == null)
            {
                return NotFound();
            }

            var our_Skill = await _context.Our_Skills
                .FirstOrDefaultAsync(m => m.Our_SkillId == id);
            if (our_Skill == null)
            {
                return NotFound();
            }

            return View(our_Skill);
        }

        // GET: Our_Skill/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Our_Skill/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Our_SkillId,Title,Description,Image")] Our_Skill our_Skill, IFormFile Image)
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
                    our_Skill.Image = "/uploads/" + uniqueFileName; // Relative path to the image

                    _context.Add(our_Skill);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(our_Skill);
        }

        // GET: Our_Skill/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Our_Skills == null)
            {
                return NotFound();
            }

            var our_Skill = await _context.Our_Skills.FindAsync(id);
            if (our_Skill == null)
            {
                return NotFound();
            }
            return View(our_Skill);
        }

        // POST: Our_Skill/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Our_SkillId,Title,Description,Image")] Our_Skill our_Skill, IFormFile Image)
        {
            if (id != our_Skill.Our_SkillId)
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
                        our_Skill.Image = "/uploads/" + uniqueFileName; // Relative path to the image
                    }
                    _context.Update(our_Skill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Our_SkillExists(our_Skill.Our_SkillId))
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
            return View(our_Skill);
        }

        // GET: Our_Skill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Our_Skills == null)
            {
                return NotFound();
            }

            var our_Skill = await _context.Our_Skills
                .FirstOrDefaultAsync(m => m.Our_SkillId == id);
            if (our_Skill == null)
            {
                return NotFound();
            }

            return View(our_Skill);
        }

        // POST: Our_Skill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Our_Skills == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Our_Skills'  is null.");
            }
            var our_Skill = await _context.Our_Skills.FindAsync(id);
            if (our_Skill != null)
            {
                _context.Our_Skills.Remove(our_Skill);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Our_SkillExists(int id)
        {
          return (_context.Our_Skills?.Any(e => e.Our_SkillId == id)).GetValueOrDefault();
        }
    }
}
