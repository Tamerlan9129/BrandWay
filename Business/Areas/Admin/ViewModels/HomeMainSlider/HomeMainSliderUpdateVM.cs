namespace Business.Areas.Admin.ViewModels.HomeMainSlider
{
    public class HomeMainSliderUpdateVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFile? Photo { get; set; }
        public int Order { get; set; }
        public string ButtonLink { get; set; }
    }
}
