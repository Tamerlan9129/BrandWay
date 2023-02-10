using Business.Areas.Admin.Services.Asbract;
using Business.Areas.Admin.ViewModels.Info;
using Core.Entities;
using Core.Utilities.FileService;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Business.Areas.Admin.Services.Concrete
{
    public class InfoService : IInfoService
    {
        private readonly ModelStateDictionary _modelState;
        private readonly IInfoRepository _infoRepository;
        private readonly IFileService _fileService;

        public InfoService(IActionContextAccessor actionContextAccessor,
            IInfoRepository teamRepository,
            IFileService fileService)
        {
            _modelState = actionContextAccessor.ActionContext.ModelState;
            _infoRepository = teamRepository;
            _fileService = fileService;
        }
        public async Task<bool> CreateAsync(InfoCreateVM model)
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

            var info = new Info
            {
                CreatedAt = DateTime.Now,
                Description = model.Description,
                PhotoName = await _fileService.UploadAsync(model.Photo),
                Title = model.Title
            };
            await _infoRepository.CreateAsync(info);
            return true;

        }

        public async Task DeleteAsync(int id)
        {
            var info = await _infoRepository.GetAsync(id);
            await _infoRepository.DeleteAsync(info);
        }

        public async Task<InfoIndexVM> GetAllAsync()
        {
            var infos = await _infoRepository.GetAllAsync();
            var model = new InfoIndexVM
            {
                Infos = infos
            };
            return model;
        }

        public async Task<InfoUpdateVM> GetUpdateModelAsync(int id)
        {
            var info = await _infoRepository.GetAsync(id);
            var model = new InfoUpdateVM
            {
                Id = info.Id,
                Description = info.Description,
                Title = info.Title
            };
            return model;
        }

        public async Task<bool> UpdateAsync(InfoUpdateVM model)
        {
            if (!_modelState.IsValid) return false;

            var info = await _infoRepository.GetAsync(model.Id);
            info.Description = model.Description;
            info.ModifiedAt = DateTime.Now;
            info.Title = model.Title;

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
                _fileService.Delete(info.PhotoName);
                info.PhotoName = await _fileService.UploadAsync(model.Photo);
            }
            await _infoRepository.UpdateAsync(info);
            return true;
        }
    }
}
