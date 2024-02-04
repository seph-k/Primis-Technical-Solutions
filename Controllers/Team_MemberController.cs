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
    public class Team_MemberController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; // Add this line

        public Team_MemberController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Team_Member
        public async Task<IActionResult> Index()
        {
              return _context.Team_Members != null ? 
                          View(await _context.Team_Members.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Team_Members'  is null.");
        }

        // GET: Team_Member/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Team_Members == null)
            {
                return NotFound();
            }

            var team_Member = await _context.Team_Members
                .FirstOrDefaultAsync(m => m.Team_MemberId == id);
            if (team_Member == null)
            {
                return NotFound();
            }

            return View(team_Member);
        }

        // GET: Team_Member/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Team_Member/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Team_MemberId,Name,Position,Image")] Team_Member team_Member, IFormFile Image)
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
                    team_Member.Image = "/uploads/" + uniqueFileName; // Relative path to the image

                    _context.Add(team_Member);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(team_Member);
        }

        // GET: Team_Member/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Team_Members == null)
            {
                return NotFound();
            }

            var team_Member = await _context.Team_Members.FindAsync(id);
            if (team_Member == null)
            {
                return NotFound();
            }
            return View(team_Member);
        }

        // POST: Team_Member/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Team_MemberId,Name,Position,Image")] Team_Member team_Member, IFormFile Image)
        {
            if (id != team_Member.Team_MemberId)
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
                        team_Member.Image = "/uploads/" + uniqueFileName; // Relative path to the image
                    }
                    _context.Update(team_Member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Team_MemberExists(team_Member.Team_MemberId))
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
            return View(team_Member);
        }

        // GET: Team_Member/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Team_Members == null)
            {
                return NotFound();
            }

            var team_Member = await _context.Team_Members
                .FirstOrDefaultAsync(m => m.Team_MemberId == id);
            if (team_Member == null)
            {
                return NotFound();
            }

            return View(team_Member);
        }

        // POST: Team_Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Team_Members == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Team_Members'  is null.");
            }
            var team_Member = await _context.Team_Members.FindAsync(id);
            if (team_Member != null)
            {
                _context.Team_Members.Remove(team_Member);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Team_MemberExists(int id)
        {
          return (_context.Team_Members?.Any(e => e.Team_MemberId == id)).GetValueOrDefault();
        }
    }
}
