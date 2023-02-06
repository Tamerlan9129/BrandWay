using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
