using System.ComponentModel.DataAnnotations;

namespace Business.Areas.Admin.ViewModels.AboutStore
{
    public class AboutStoreUpdateVM
    {
        public int Id { get; set; }

        public IFormFile? Photo { get; set; }
        [Required]

        public string Title { get; set; }
        [Required]

        public string SubTitle { get; set; }
        [Required]

        public string Description { get; set; }
    }
}
