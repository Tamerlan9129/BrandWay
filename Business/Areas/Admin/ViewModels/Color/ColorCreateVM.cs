using System.ComponentModel.DataAnnotations;

namespace Business.Areas.Admin.ViewModels.Color
{
    public class ColorCreateVM
    {
        [Required]
        public string Title { get; set; }
    }
}
