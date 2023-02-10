using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Business.Areas.Admin.ViewModels.Contact
{
    public class ContactIndexVM
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string Careers { get; set; }

        public string MondayToSaturday { get; set; }

        public string Sundays { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
