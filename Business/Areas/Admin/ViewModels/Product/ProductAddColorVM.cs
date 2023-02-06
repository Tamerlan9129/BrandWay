using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Business.Areas.Admin.ViewModels.Product
{
    public class ProductAddColorVM
    {
        public int ProductId { get; set; }
        [Display(Name = "Colors")]
        [Required]
        public List<int> ColorsIds { get; set; }
        public List<SelectListItem>? Colors { get; set; }
    }
}
