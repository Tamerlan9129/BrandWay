using Business.Areas.Admin.Services.Asbract;
using Business.Areas.Admin.ViewModels.Brand;
using Core.Entities;
using Core.Utilities.FileService;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Business.Areas.Admin.Services.Concrete
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IFileService _fileService;
        private readonly ModelStateDictionary _modelState;

        public BrandService(IBrandRepository brandRepository,
            IActionContextAccessor actionContextAccessor,
            IFileService fileService)
        {
            _brandRepository = brandRepository;
            _fileService = fileService;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }
        public async Task<bool> CreateAsync(BrandCreateVM model)
        {
            if (!_modelState.IsValid) return false;
            var isExist = await _brandRepository.AnyAsync(b => b.Title.Trim().ToLower() == model.Title.Trim().ToLower());
            if (isExist)
            {
                _modelState.AddModelError("Title", "This brand already created");
                return false;
            }
            var brand = new Brand
            {
                Title = model.Title,
                CreatedAt = DateTime.Now,
            };
            await _brandRepository.CreateAsync(brand);
            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var brand = await _brandRepository.GetAsync(id);
            await _brandRepository.DeleteAsync(brand);
        }

        public async Task<BrandIndexVM> GetAllAsync()
        {
            var model = new BrandIndexVM
            {
                Brands = await _brandRepository.GetAllAsync()
            };
            return model;
        }

        public async Task<BrandUpdateVM> GetUpdateModelAsync(int id)
        {
            var brand = await _brandRepository.GetAsync(id);
            var model = new BrandUpdateVM
            {
                Title = brand.Title,
                Id = brand.Id,
            };
            return model;
        }

        public async Task<bool> UpdateAsync(BrandUpdateVM model)
        {
            if (!_modelState.IsValid) return false;
            var brand = await _brandRepository.GetAsync(model.Id);
            var isExist = await _brandRepository.AnyAsync(b => b.Title.Trim().ToLower() == model.Title.Trim().ToLower()
            && b.Id != model.Id);
            if (isExist)
            {
                _modelState.AddModelError("Title", "This brand already created");
                return false;
            }
            brand.Title = model.Title;
            brand.ModifiedAt = DateTime.Now;
            await _brandRepository.UpdateAsync(brand);
            return true;
        }
    }
}
