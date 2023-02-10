using Business.Areas.Admin.Services.Asbract;
using Business.Areas.Admin.Services.Concrete;
using Business.Areas.Admin.ViewModels.AboutStore;
using Business.Areas.Admin.ViewModels.Info;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Business.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class InfoController : Controller
    {
        private readonly IInfoService _infoService;

        public InfoController(IInfoService infoService)
        {
            _infoService = infoService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _infoService.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(InfoCreateVM model)
        {
            var isSucceded = await _infoService.CreateAsync(model);
            if (isSucceded) return RedirectToAction(nameof(Index));
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _infoService.GetUpdateModelAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(InfoUpdateVM model, int id)
        {
            if (model.Id != id) return BadRequest();
            var isSucceded = await _infoService.UpdateAsync(model);
            if (isSucceded) return RedirectToAction(nameof(Index));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _infoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
