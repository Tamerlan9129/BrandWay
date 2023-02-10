using Business.Areas.Admin.Services.Asbract;
using Business.Areas.Admin.Services.Concrete;
using Business.Areas.Admin.ViewModels.Features;
using Business.Areas.Admin.ViewModels.Info;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Business.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class FeaturesController : Controller
    {
        private readonly IFeaturesService _featuresService;

        public FeaturesController(IFeaturesService featuresService)
        {
            _featuresService = featuresService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _featuresService.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FeaturesCreateVM model)
        {
            var isSucceded = await _featuresService.CreateAsync(model);
            if (isSucceded) return RedirectToAction(nameof(Index));
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _featuresService.GetUpdateModelAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(FeaturesUpdateVM model, int id)
        {
            if (model.Id != id) return BadRequest();
            var isSucceded = await _featuresService.UpdateAsync(model);
            if (isSucceded) return RedirectToAction(nameof(Index));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _featuresService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
