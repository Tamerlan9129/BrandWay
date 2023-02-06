using Business.Areas.Admin.ViewModels.Size;

namespace Business.Areas.Admin.Services.Asbract
{
    public interface ISizeService
    {
        Task<bool> CreateAsync(SizeCreateVM model);
        Task<bool> UpdateAsync(SizeUpdateVM model);
        Task<SizeUpdateVM> GetUpdateModelAsync(int id);
        Task DeleteAsync(int id);
        Task<SizeIndexVM> GetAllAsync();
    }
}
