using Core.Entities;

namespace Business.ViewModels.Home
{
    public class HomeIndexVM
    {
        public List<Brand> Brands { get; set; }
        public List<Core.Entities.Product> BestSellingProducts { get; set; }
        public List<Core.Entities.Product> Products { get; set; }
        public List<Core.Entities.Testimonial> Testimonials { get; set; }
        public List<Core.Entities.HomeMainSlider> HomeMainSliders { get; set; }


    }
}
