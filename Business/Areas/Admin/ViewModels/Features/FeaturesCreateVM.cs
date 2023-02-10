using System.ComponentModel.DataAnnotations;

namespace Business.Areas.Admin.ViewModels.Features
{
    public class FeaturesCreateVM
    {
        [Required]
        public string Title { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]

        public IFormFile Photo { get; set; }
    }
}
