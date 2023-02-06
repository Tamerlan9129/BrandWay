using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers
{
    public class ShopController : Controller
    {
        public  IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details()
        {
            return View();
        }
    }
}
