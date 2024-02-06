using Primis_Technical_Solutions.Models;

namespace Primis_Technical_Solutions.viewModel
{
    public class ServiceViewModel
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        // Other properties...

        public IEnumerable<Introductory_Content> Introductory_Contents { get; set; }
        public IEnumerable<Our_Feature> Our_Features { get; set; }
        public IEnumerable<Banner_Logo> Banner_Logos { get; set; }

    }
}
