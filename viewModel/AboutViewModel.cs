using Microsoft.EntityFrameworkCore;
using Primis_Technical_Solutions.Models;

namespace Primis_Technical_Solutions.viewModel
{
    public class AboutViewModel
    {

        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        // Other properties...
        public IEnumerable<Introductory_Content> Introductory_Contents { get; set; }
        public IEnumerable<Our_Sevice> Our_Sevices { get; set; }
        public IEnumerable<Our_Feature> Our_Features { get; set; }
        public IEnumerable<Our_Partner> Our_Partners { get; set; }
        public IEnumerable<Our_Team> Our_Teams { get; set; }
        public IEnumerable<Team_Member> Team_Members { get; set; }
        public IEnumerable<Partners_Section> Partners_Sections { get; set; }
        public IEnumerable<Banner_Logo> Banner_Logos { get; set; }


    }
}
