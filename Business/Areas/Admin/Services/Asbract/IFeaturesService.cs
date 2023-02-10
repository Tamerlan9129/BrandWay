using Business.Areas.Admin.ViewModels.AboutStore;
using Business.Areas.Admin.ViewModels.Features;

namespace Business.Areas.Admin.Services.Asbract
{
    public interface IFeaturesService
    {
        Task<FeaturesIndexVM> GetAllAsync();
        Task<bool> CreateAsync(FeaturesCreateVM model);
        Task<FeaturesUpdateVM> GetUpdateModelAsync(int id);
        Task<bool> UpdateAsync(FeaturesUpdateVM model);
        Task DeleteAsync(int id);
    }
}
