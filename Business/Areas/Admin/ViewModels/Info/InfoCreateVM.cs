using Microsoft.Build.Framework;

namespace Business.Areas.Admin.ViewModels.Info
{
    public class InfoCreateVM
    {
        [Required]
        public IFormFile Photo { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
