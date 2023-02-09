using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Business.ViewComponents
{
    public class OurServiceViewComponent : ViewComponent
    {
        private readonly IOurServiceRepository _ourServiceRepository;

        public OurServiceViewComponent(IOurServiceRepository ourServiceRepository)
        {
            _ourServiceRepository = ourServiceRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _ourServiceRepository.GetAllAsync();
            return View(result);
        }
    }
}
