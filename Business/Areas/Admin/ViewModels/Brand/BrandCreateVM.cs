using System.ComponentModel.DataAnnotations;

namespace Business.Areas.Admin.ViewModels.Brand
{
    public class BrandCreateVM
    {
        [Required]
        public string Title { get; set; }

    }
}
