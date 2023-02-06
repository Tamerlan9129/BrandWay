using System.ComponentModel.DataAnnotations;

namespace Business.Areas.Admin.ViewModels.Color
{
    public class ColorUpdateVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
