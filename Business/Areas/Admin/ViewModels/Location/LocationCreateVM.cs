using System.ComponentModel.DataAnnotations;

namespace Business.Areas.Admin.ViewModels.Location
{
    public class LocationCreateVM
    {
        [Required]
        public string Url { get; set; }
    }
}
