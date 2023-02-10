using Business.Areas.Admin.Services.Asbract;
using Business.Areas.Admin.ViewModels.AboutStore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System.Data;

namespace Business.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AboutStoreController : Controller
    {
        private readonly IAboutStoreService _aboutStoreService;

        public AboutStoreController(IAboutStoreService aboutStoreService)
        {
            _aboutStoreService = aboutStoreService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _aboutStoreService.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AboutStoreCreateVM model)
        {
            var isSucceded = await _aboutStoreService.CreateAsync(model);
            if (isSucceded) return RedirectToAction(nameof(Index));
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _aboutStoreService.GetUpdateModelAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AboutStoreUpdateVM model, int id)
        {
            if (model.Id != id) return BadRequest();
            var isSucceded = await _aboutStoreService.UpdateAsync(model);
            if (isSucceded) return RedirectToAction(nameof(Index));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _aboutStoreService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
