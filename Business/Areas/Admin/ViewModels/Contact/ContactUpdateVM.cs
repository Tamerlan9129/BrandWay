using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Business.Areas.Admin.ViewModels.Contact
{
    public class ContactUpdateVM
    {
        [Required]
        public string Address { get; set; }
        [Required, DataType(DataType.PhoneNumber)]

        public string PhoneNumber { get; set; }
        [Required, DataType(DataType.EmailAddress)]

        public string EmailAddress { get; set; }
        [Required]

        public string Careers { get; set; }
        [Required, Display(Name = "Monday To Saturday ")]

        public string MondayToSaturday { get; set; }
        [Required]

        public string Sundays { get; set; }
    }
}
