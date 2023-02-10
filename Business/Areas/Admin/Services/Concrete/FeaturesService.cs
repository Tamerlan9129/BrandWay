using Business.Areas.Admin.Services.Asbract;
using Business.Areas.Admin.ViewModels.Features;
using Core.Entities;
using Core.Utilities.FileService;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Business.Areas.Admin.Services.Concrete
{
    public class FeaturesService : IFeaturesService
    {
        private readonly ModelStateDictionary _modelState;
        private readonly IFeaturesRepository _featuresRepository;
        private readonly IFileService _fileService;

        public FeaturesService(IActionContextAccessor actionContextAccessor,
            IFeaturesRepository teamRepository,
            IFileService fileService)
        {
            _modelState = actionContextAccessor.ActionContext.ModelState;
            _featuresRepository = teamRepository;
            _fileService = fileService;
        }
        public async Task<bool> CreateAsync(FeaturesCreateVM model)
        {
            if (!_modelState.IsValid) return false;
            var maxSize = 5000;
            if (!_fileService.CheckPhoto(model.Photo))
            {
                _modelState.AddModelError("Photo", "File must be image format");
                return false;
            }
            else if (!_fileService.MaxSize(model.Photo, maxSize))
            {
                _modelState.AddModelError("Photo", $"Photo size must be less than {maxSize} kb;");
                return false;
            }

            var features = new Features
            {
                CreatedAt = DateTime.Now,
                Description = model.Description,
                PhotoName = await _fileService.UploadAsync(model.Photo),
                Title = model.Title
            };
            await _featuresRepository.CreateAsync(features);
            return true;

        }

        public async Task DeleteAsync(int id)
        {
            var testimonial = await _featuresRepository.GetAsync(id);
            await _featuresRepository.DeleteAsync(testimonial);
        }

        public async Task<FeaturesIndexVM> GetAllAsync()
        {
            var featuress = await _featuresRepository.GetAllAsync();
            var model = new FeaturesIndexVM
            {
                Features = featuress
            };
            return model;
        }

        public async Task<FeaturesUpdateVM> GetUpdateModelAsync(int id)
        {
            var features = await _featuresRepository.GetAsync(id);
            var model = new FeaturesUpdateVM
            {
                Id = features.Id,
                Description = features.Description,
                Title = features.Title
            };
            return model;
        }

        public async Task<bool> UpdateAsync(FeaturesUpdateVM model)
        {
            if (!_modelState.IsValid) return false;

            var features = await _featuresRepository.GetAsync(model.Id);
            features.Description = model.Description;
            features.ModifiedAt = DateTime.Now;
            features.Title = model.Title;

            if (model.Photo != null)
            {
                var maxSize = 3000;
                if (!_fileService.CheckPhoto(model.Photo))
                {
                    _modelState.AddModelError("Photo", "File must be image format");
                    return false;
                }
                else if (!_fileService.MaxSize(model.Photo, maxSize))
                {
                    _modelState.AddModelError("Photo", $"Photo size must be less than {maxSize} kb;");
                    return false;
                }
                _fileService.Delete(features.PhotoName);
                features.PhotoName = await _fileService.UploadAsync(model.Photo);
            }
            await _featuresRepository.UpdateAsync(features);
            return true;
        }
    }
}
