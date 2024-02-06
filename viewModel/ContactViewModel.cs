using Microsoft.EntityFrameworkCore;
using Primis_Technical_Solutions.Models;

namespace Primis_Technical_Solutions.viewModel
{
    public class ContactViewModel
    {
        public IEnumerable<Introductory_Content> Introductory_Contents { get; set; }
        public IEnumerable<Contact_Reason> Contact_Reasons { get; set; }
        public IEnumerable<Banner_Logo> Banner_Logos { get; set; }

    }
}
