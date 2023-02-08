using Business.Areas.Admin.ViewModels.OurService;

namespace Business.Areas.Admin.Services.Asbract
{
    public interface IOurServiceService
    {
        Task<OurServiceIndexVM> GetAllAsync();
        Task<bool> CreateAsync(OurServiceCreateVM model);
        Task<OurServiceUpdateVM> GetUpdateModelAsync(int id);
        Task<bool> UpdateAsync(OurServiceUpdateVM model);
        Task DeleteAsync(int id);
    }
}
