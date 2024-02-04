using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Primis_Technical_Solutions.Models;

namespace Primis_Technical_Solutions.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
        public DbSet<Home_Banner> Home_Banners { get; set; }
        public DbSet<Contact_Reason> Contact_Reasons { get; set; }
        public DbSet<Partners_Section> Partners_Sections { get; set; }
        public DbSet<Our_Partner> Our_Partners { get; set; }
        public DbSet<Our_Team> Our_Teams { get; set; }
        public DbSet<Our_Industry> Our_Industries { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Our_Sector> Our_Sectors { get; set; }
        public DbSet<Team_Member> Team_Members { get; set; }
        public DbSet<Our_Feature> Our_Features { get; set; }
        public DbSet<Our_Skill> Our_Skills { get; set; }
        public DbSet<Our_Sevice> Our_Sevices { get; set; }
        public DbSet<Introductory_Content> Introductory_Contents { get; set; }

    }
}
