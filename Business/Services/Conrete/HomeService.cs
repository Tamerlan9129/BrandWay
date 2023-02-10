using Business.Services.Abstract;
using Business.ViewModels.Home;
using DataAccess.Repositories.Abstract;

namespace Business.Services.Conrete
{
    public class HomeService : IHomeService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IProductRepository _productRepository;
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly IHomeMainSliderRepository _homeMainSliderRepository;

        public HomeService(IBrandRepository brandRepository,
            IProductRepository productRepository,
            ITestimonialRepository testimonialRepository,
            IHomeMainSliderRepository homeMainSliderRepository)
        {
            _productRepository = productRepository;
            _testimonialRepository = testimonialRepository;
            _homeMainSliderRepository = homeMainSliderRepository;
            _brandRepository = brandRepository;
        }
        public async Task<HomeIndexVM> GetAllAsync()
        {
            var model = new HomeIndexVM
            {
                Brands = await _brandRepository.GetAllAsync(),
                BestSellingProducts = await _productRepository.GetProductsBestSellingAsync(),
                Products = await _productRepository.GetAllAsync(),
                Testimonials = await _testimonialRepository.GetAllAsync(),
                HomeMainSliders = await _homeMainSliderRepository.GetAllAsync(),
                ExploreProducts=await _productRepository.GetProductsExploreSellingAsync()
               
            };
            return model;
        }
    }
}

