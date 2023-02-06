using Business.Services.Abstract;
using Business.ViewModels.Home;
using DataAccess.Repositories.Abstract;

namespace Business.Services.Conrete
{
    public class HomeService : IHomeService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IProductRepository _productRepository;


        public HomeService(IBrandRepository brandRepository,
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
        }
        public async Task<HomeIndexVM> GetAllAsync()
        {
            var model = new HomeIndexVM
            {
                Brands = await _brandRepository.GetAllAsync(),
                BestSellingProducts = await _productRepository.GetProductsBestSellingAsync(),
                Products = await _productRepository.GetAllAsync()
            };
            return model;
        }
    }
}

