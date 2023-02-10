using Business.Areas.Admin.ViewModels.Location;

namespace Business.Areas.Admin.Services.Asbract
{
    public interface ILocationService
    {
        Task<LocationIndexVM> GetAsync();
        Task<bool> CreateAsync(LocationCreateVM model);
        Task<LocationUpdateVM> GetUpdateModelAsync();
        Task<bool> UpdateAsync(LocationUpdateVM model);
        Task DeleteAsync();
        Task<bool> IsExistAsync();
    }
}
