using Business.Areas.Admin.ViewModels.AboutStore;
using Business.Areas.Admin.ViewModels.Info;

namespace Business.Areas.Admin.Services.Asbract
{
    public interface IInfoService
    {
        Task<InfoIndexVM> GetAllAsync();
        Task<bool> CreateAsync(InfoCreateVM model);
        Task<InfoUpdateVM> GetUpdateModelAsync(int id);
        Task<bool> UpdateAsync(InfoUpdateVM model);
        Task DeleteAsync(int id);
    }
}
