using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers
{
    public class FavouriteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
