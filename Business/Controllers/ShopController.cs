using Business.Areas.Admin.Services.Asbract;
using Business.Services.Abstract;
using Business.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }
        public async Task<IActionResult> Index(ProductIndexVM model)
        {
            model = await _shopService.GetAllAsync(model);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _shopService.GetDetailsAsync(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> LoadMore(int skipRow)
        {
            var model = await _shopService.GetLoadMoreAsync(skipRow);
            return PartialView("_ProductsPartial", model);
        }


        [HttpGet]
        public async Task<IActionResult> FilterByName(string? name)
        {
            var model = await _shopService.FilterAllByName(name);
            return PartialView("_SearchProductPartial", model);
        }
    }
}
