using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
