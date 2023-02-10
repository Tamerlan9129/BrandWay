using Microsoft.Build.Framework;

namespace Business.Areas.Admin.ViewModels.AboutStore
{
    public class AboutStoreCreateVM
    {
        [Required]
        public IFormFile Photo { get; set; }
        [Required]

        public string Title { get; set; }
        [Required]

        public string SubTitle { get; set; }
        [Required]

        public string Description { get; set; }
    }
}
