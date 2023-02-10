using Business.Areas.Admin.Services.Asbract;
using Business.Areas.Admin.ViewModels.AboutStore;
using Business.Areas.Admin.ViewModels.Team;
using Core.Entities;
using Core.Utilities.FileService;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Business.Areas.Admin.Services.Concrete
{
    public class AboutStoreService : IAboutStoreService
    {
        private readonly ModelStateDictionary _modelState;
        private readonly IAboutStoreRepository _aboutStoreRepository;
        private readonly IFileService _fileService;

        public AboutStoreService(IActionContextAccessor actionContextAccessor,
            IAboutStoreRepository teamRepository,
            IFileService fileService)
        {
            _modelState = actionContextAccessor.ActionContext.ModelState;
            _aboutStoreRepository = teamRepository;
            _fileService = fileService;
        }
        public async Task<bool> CreateAsync(AboutStoreCreateVM model)
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

            var aboutStore = new AboutStore
            {
                CreatedAt = DateTime.Now,
                Description = model.Description,
                PhotoName = await _fileService.UploadAsync(model.Photo),
                SubTitle = model.SubTitle,
                Title = model.Title
            };
            await _aboutStoreRepository.CreateAsync(aboutStore);
            return true;

        }

        public async Task DeleteAsync(int id)
        {
            var testimonial = await _aboutStoreRepository.GetAsync(id);
            await _aboutStoreRepository.DeleteAsync(testimonial);
        }

        public async Task<AboutStoreIndexVM> GetAllAsync()
        {
            var aboutStores = await _aboutStoreRepository.GetAllAsync();
            var model = new AboutStoreIndexVM
            {
                AboutStores = aboutStores
            };
            return model;
        }

        public async Task<AboutStoreUpdateVM> GetUpdateModelAsync(int id)
        {
            var aboutStore = await _aboutStoreRepository.GetAsync(id);
            var model = new AboutStoreUpdateVM
            {
                Id = aboutStore.Id,
                Description = aboutStore.Description,
                SubTitle = aboutStore.SubTitle,
                Title = aboutStore.Title
            };
            return model;
        }

        public async Task<bool> UpdateAsync(AboutStoreUpdateVM model)
        {
            if (!_modelState.IsValid) return false;

            var aboutStore = await _aboutStoreRepository.GetAsync(model.Id);
            aboutStore.Description = model.Description;
            aboutStore.ModifiedAt = DateTime.Now;
            aboutStore.Title = model.Title;
            aboutStore.SubTitle = model.SubTitle;

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
                _fileService.Delete(aboutStore.PhotoName);
                aboutStore.PhotoName = await _fileService.UploadAsync(model.Photo);
            }
            await _aboutStoreRepository.UpdateAsync(aboutStore);
            return true;
        }
    }
}
