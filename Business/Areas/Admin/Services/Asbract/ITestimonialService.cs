using Business.Areas.Admin.ViewModels.Testimonial;

namespace Business.Areas.Admin.Services.Asbract
{
    public interface ITestimonialService
    {
        Task<TestimonialIndexVM> GetAllAsync();
        Task<bool> CreateAsync(TestimonialCreateVM model);
        Task<TestimonialUpdateVM> GetUpdateModelAsync(int id);
        Task<bool> UpdateAsync(TestimonialUpdateVM model);
        Task DeleteAsync(int id);
    }
}
