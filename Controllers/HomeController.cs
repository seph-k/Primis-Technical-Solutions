using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Primis_Technical_Solutions.Data;
using Primis_Technical_Solutions.Models;
using Primis_Technical_Solutions.viewModel;
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
            // Fetch the data from the database (replace YourDbContext with your actual DbContext class name)
            var introductoryContents = _context.Introductory_Contents.ToList();
            var homeBanners = _context.Home_Banners.ToList();
            var ourServices = _context.Our_Sevices.ToList();
            var ourSkills = _context.Our_Skills.ToList();
            var ourSectors = _context.Our_Sectors.ToList();
            var ourFeatures = _context.Our_Features.ToList();
            var portfolios = _context.Portfolios.ToList();
            var ourIndustries = _context.Our_Industries.ToList();
            var bannerLogo = _context.Banner_Logos.ToList();

            // Add the data collected to the view model (replace HomeViewModel with your actual ViewModel class name)
            var homeviewmodel = new HomeViewModel
            {
                Introductory_Contents = introductoryContents,
                Home_Banners = homeBanners,
                Our_Sevices = ourServices,
                Our_Skills = ourSkills,
                Our_Sectors = ourSectors,
                Our_Features = ourFeatures,
                Portfolios = portfolios,
                Our_Industries = ourIndustries,
                Banner_Logos = bannerLogo
            };

            return View(homeviewmodel);

        }

        public IActionResult About()
        {
            // Assuming _context is an instance of your DbContext (replace YourDbContext with your actual DbContext class name)
            var introductoryContents = _context.Introductory_Contents.ToList();
            var ourServices = _context.Our_Sevices.ToList();
            var ourFeatures = _context.Our_Features.ToList();
            var ourPartners = _context.Our_Partners.ToList();
            var ourTeams = _context.Our_Teams.ToList();
            var teamMembers = _context.Team_Members.ToList();
            var partnersSections = _context.Partners_Sections.ToList();
            var bannerLogo = _context.Banner_Logos.ToList();


            // Create a ViewModel to hold the data (replace HomeViewModel with your actual ViewModel class name)
            var aboutviewmodel = new AboutViewModel
            {
                Introductory_Contents = introductoryContents,
                Our_Sevices = ourServices,
                Our_Features = ourFeatures,
                Our_Partners = ourPartners,
                Our_Teams = ourTeams,
                Team_Members = teamMembers,
                Partners_Sections = partnersSections,
                Banner_Logos = bannerLogo,
            };

            // Pass the ViewModel to the view
            return View(aboutviewmodel);

        }

        public IActionResult Contact()
        {
            // Assuming _context is an instance of your DbContext (replace YourDbContext with your actual DbContext class name)
            var introductoryContents = _context.Introductory_Contents.ToList();
            var contactReasons = _context.Contact_Reasons.ToList();
            var bannerLogo = _context.Banner_Logos.ToList();


            // Create a ViewModel to hold the data (replace HomeViewModel with your actual ViewModel class name)
            var contactviewmodel = new ContactViewModel
            {
                Introductory_Contents = introductoryContents,
                Contact_Reasons = contactReasons,
                Banner_Logos = bannerLogo
            };

            // Pass the ViewModel to the view
            return View(contactviewmodel);

        }

        public IActionResult Services(string image, string title, string description)
        {

            // Assuming _context is an instance of your DbContext (replace YourDbContext with your actual DbContext class name)
            var introductoryContents = _context.Introductory_Contents.ToList();
            var ourFeatures = _context.Our_Features.ToList();
            var bannerLogo = _context.Banner_Logos.ToList();


            // Create a ViewModel to hold the data (replace HomeViewModel with your actual ViewModel class name)
            var serviceviewmodel = new ServiceViewModel
            {
                Introductory_Contents = introductoryContents,
                Our_Features = ourFeatures,
                Banner_Logos = bannerLogo,
                Image = image,
                Title = title,
                Description = description
            };

            // Pass the ViewModel to the view
            return View(serviceviewmodel);

            //// Fetch the data from the database (replace YourDbContext with your actual DbContext class name)
            //var introductoryContents = _context.Introductory_Contents.ToList();
            //var homeBanners = _context.Home_Banners.ToList();
            //var ourServices = _context.Our_Sevices.ToList();
            //var ourSkills = _context.Our_Skills.ToList();
            //var ourSectors = _context.Our_Sectors.ToList();
            //var ourFeatures = _context.Our_Features.ToList();
            //var portfolios = _context.Portfolios.ToList();
            //var ourIndustries = _context.Our_Industries.ToList();
            //var bannerLogo = _context.Banner_Logos.ToList();

            //// Add the data collected to the view model (replace HomeViewModel with your actual ViewModel class name)
            //var homeviewmodel = new HomeViewModel
            //{
            //    Introductory_Contents = introductoryContents,
            //    Home_Banners = homeBanners,
            //    Our_Sevices = ourServices,
            //    Our_Skills = ourSkills,
            //    Our_Sectors = ourSectors,
            //    Our_Features = ourFeatures,
            //    Portfolios = portfolios,
            //    Our_Industries = ourIndustries,
            //    Banner_Logos = bannerLogo,
            //    Image = image,
            //    Title = title,
            //    Description = description
            //};

            //return View(homeviewmodel);

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
