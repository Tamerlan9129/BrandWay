using Microsoft.AspNetCore.Mvc.Rendering;

namespace Business.ViewModels.Favourite
{
    public class FavouriteListItemVM
    {
        public int Id { get; set; }

        public double Price { get; set; }
        public string Title { get; set; }
        public string PhotoName { get; set; }
        public int SizeId { get; set; }
        public List<SelectListItem> Sizes { get; set; }
    }
}
