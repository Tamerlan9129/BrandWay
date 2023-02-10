using Business.ViewModels.About;

namespace Business.Services.Abstract
{
    public interface IAboutService
    {
        Task<AboutIndexVM> GetAllAsync();
    }
}
