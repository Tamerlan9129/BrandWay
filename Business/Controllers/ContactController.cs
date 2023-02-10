using Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _contactService.GetAllAsync();
            return View(model);
        }
    }
}
