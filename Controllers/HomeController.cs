using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Primis_Technical_Solutions.Data;
using Primis_Technical_Solutions.Models;
using System.Diagnostics;

namespace Primis_Technical_Solutions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
            ////fetch the data from the database, add _context if it missing 
            //var banner = _context.Home_Banners.ToList();
            //var ourgoals = _context.Objectives.ToList();
            //var corperateinfo = _context.Corperate_Infos.ToList();
            //var projects = _context.Projects.Include(m => m.Project_Title).ToList();
            //var cotragecocontent = _context.Cotrageco_Contents.ToList();
            //var allbanners = _context.Banner.ToList();

            //// add the data collected to the view model, dont forget to pass the object in parameter
            //var homeviewmodel = new HomeViewModel
            //{
            //    Home_Banners = banner,
            //    Objectives = ourgoals,
            //    Corperate_Infos = corperateinfo,
            //    Projects = projects,
            //    cotrageco_Contents = cotragecocontent,
            //    Banner = allbanners
            //};
            //return View(homeviewmodel);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
