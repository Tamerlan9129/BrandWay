using Business.ViewModels.Components;
using Business.ViewModels.Product;

namespace Business.Services.Abstract
{
    public interface IShopService
    {
        Task<ProductIndexVM> GetAllAsync(ProductIndexVM model);
        Task<ProductDetailsVM> GetDetailsAsync(int id);
        Task<ProductLoadMoreVM> GetLoadMoreAsync(int skipRow);
        Task<HeaderComponentVM> FilterAllByName(string? name);
    }
}
