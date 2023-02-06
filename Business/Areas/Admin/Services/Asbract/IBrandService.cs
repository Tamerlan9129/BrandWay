using Business.Areas.Admin.ViewModels.Brand;

namespace Business.Areas.Admin.Services.Asbract
{
    public interface IBrandService
    {
        Task<bool> CreateAsync(BrandCreateVM model);
        Task<bool> UpdateAsync(BrandUpdateVM model);
        Task<BrandUpdateVM> GetUpdateModelAsync(int id);
        Task DeleteAsync(int id);
        Task<BrandIndexVM> GetAllAsync();
    }
}
