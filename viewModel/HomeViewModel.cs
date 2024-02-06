using Primis_Technical_Solutions.Models;

namespace Primis_Technical_Solutions.viewModel
{
    public class HomeViewModel
    {
        //public string Image { get; set; }
        //public string Title { get; set; }
        //public string Description { get; set; }
        //// Other properties...
        public IEnumerable<Introductory_Content> Introductory_Contents { get; set; }
        public IEnumerable<Home_Banner> Home_Banners { get; set; }
        public IEnumerable<Our_Sevice> Our_Sevices { get; set; }
        public IEnumerable<Our_Skill> Our_Skills { get; set; }
        public IEnumerable<Our_Sector> Our_Sectors { get; set; }
        public IEnumerable<Our_Feature> Our_Features { get; set; }
        public IEnumerable<Portfolio> Portfolios { get; set; }
        public IEnumerable<Our_Industry> Our_Industries { get; set; }
        public IEnumerable<Banner_Logo> Banner_Logos { get; set; }



    }
}
