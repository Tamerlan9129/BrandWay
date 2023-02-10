using Business.Areas.Admin.ViewModels.AboutStore;
using Business.Areas.Admin.ViewModels.Team;

namespace Business.Areas.Admin.Services.Asbract
{
    public interface IAboutStoreService
    {
        Task<AboutStoreIndexVM> GetAllAsync();
        Task<bool> CreateAsync(AboutStoreCreateVM model);
        Task<AboutStoreUpdateVM> GetUpdateModelAsync(int id);
        Task<bool> UpdateAsync(AboutStoreUpdateVM model);
        Task DeleteAsync(int id);
    }
}
