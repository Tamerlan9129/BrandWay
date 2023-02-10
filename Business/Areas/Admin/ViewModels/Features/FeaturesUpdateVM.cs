using Microsoft.Build.Framework;

namespace Business.Areas.Admin.ViewModels.Features
{
    public class FeaturesUpdateVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]

        public string Description { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
