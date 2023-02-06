using Business.ViewModels.Home;

namespace Business.Services.Abstract
{
    public interface IHomeService
    {
        Task<HomeIndexVM> GetAllAsync();
    }
}
