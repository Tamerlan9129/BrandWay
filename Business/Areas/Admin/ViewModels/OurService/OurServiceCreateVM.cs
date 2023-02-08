using System.ComponentModel.DataAnnotations;

namespace Business.Areas.Admin.ViewModels.OurService
{
    public class OurServiceCreateVM
    {
        [Required]
        public IFormFile Icon { get; set; }
        [Required]
        [MaxLength(70)]
        public string Title { get; set; }
    }
}
