using Business.Areas.Admin.ViewModels.Color;

namespace Business.Areas.Admin.Services.Asbract
{
    public interface IColorService
    {
        Task<bool> CreateAsync(ColorCreateVM model);
        Task<bool> UpdateAsync(ColorUpdateVM model);
        Task<ColorUpdateVM> GetUpdateModelAsync(int id);
        Task DeleteAsync(int id);
        Task<ColorIndexVM> GetAllAsync();
    }
}
