using System.ComponentModel.DataAnnotations;

namespace Business.Areas.Admin.ViewModels.Location
{
    public class LocationUpdateVM
    {
        [Required]
        public string Url { get; set; }
    }
}
