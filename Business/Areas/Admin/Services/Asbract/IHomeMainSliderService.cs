using Business.Areas.Admin.ViewModels.HomeMainSlider;

namespace Business.Areas.Admin.Services.Asbract
{
    public interface IHomeMainSliderService
    {
        Task<bool> CreateAsync(HomeMainSliderCreateVM model);
        Task<bool> UpdateAsync(HomeMainSliderUpdateVM model);
        Task<HomeMainSliderUpdateVM> GetUpdateModelAsync(int id);
        Task DeleteAsync(int id);
        Task<HomeMainSliderIndexVM> GetAllAsync();
    }
}
