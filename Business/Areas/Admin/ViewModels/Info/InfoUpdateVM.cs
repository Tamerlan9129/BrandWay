using Microsoft.Build.Framework;

namespace Business.Areas.Admin.ViewModels.Info
{
    public class InfoUpdateVM
    {
        public int Id { get; set; }
        public IFormFile? Photo { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
