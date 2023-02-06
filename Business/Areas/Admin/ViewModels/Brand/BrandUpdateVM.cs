using System.ComponentModel.DataAnnotations;

namespace Business.Areas.Admin.ViewModels.Brand
{
    public class BrandUpdateVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
     
    }
}
