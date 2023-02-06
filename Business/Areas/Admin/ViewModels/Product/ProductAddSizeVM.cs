using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Business.Areas.Admin.ViewModels.Product
{
    public class ProductAddSizeVM
    {
        public int ProductId { get; set; }
        [Display(Name = "Sizes")]
        [Required]
        public List<int> SizesIds { get; set; }
        public List<SelectListItem>? Sizes { get; set; }
    }
}
