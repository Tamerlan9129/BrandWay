using Business.Areas.Admin.Services.Asbract;
using Business.Areas.Admin.ViewModels.OurService;
using Business.Services.Abstract;
using Core.Entities;
using Core.Utilities.FileService;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Business.Areas.Admin.Services.Concrete
{
    public class OurServiceService : IOurServiceService
    {
        private readonly IOurServiceRepository _ourServiceRepository;
        private readonly IFileService _fileService;
        private readonly ModelStateDictionary _modelState;

        public OurServiceService(IOurServiceRepository ourServiceRepository,
            IActionContextAccessor actionContextAccessor,
            IFileService fileService)
        {
            _ourServiceRepository = ourServiceRepository;
            _fileService = fileService;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }
        public async Task<bool> CreateAsync(OurServiceCreateVM model)
        {
            if (!_modelState.IsValid) return false;
            var isExist = await _ourServiceRepository.AnyAsync(os => os.Title.Trim().ToLower() == model.Title.Trim().ToLower());
            if (isExist)
            {
                _modelState.AddModelError("Title", "This content already created");
                return false;
            }
            int maxSize = 6000;
            if (!_fileService.CheckPhoto(model.Icon))
            {
                _modelState.AddModelError("Icon", $"File must be Image");
                return false;
            }

            else if (!_fileService.MaxSize(model.Icon, maxSize))
            {
                _modelState.AddModelError("Icon", $"Photo size must be less{maxSize} ");
                return false;
            }
            var ourService = new OurService
            {
                CreatedAt = DateTime.Now,
                Title = model.Title,
                Icon = await _fileService.UploadAsync(model.Icon)
            };
            await _ourServiceRepository.CreateAsync(ourService);
            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var ourService = await _ourServiceRepository.GetAsync(id);
            await _ourServiceRepository.DeleteAsync(ourService);
        }

        public async Task<OurServiceIndexVM> GetAllAsync()
        {
            var ourService = await _ourServiceRepository.GetAllAsync();
            var model = new OurServiceIndexVM
            {
                OurServices = ourService,
            };
            return model;
        }

        public async Task<OurServiceUpdateVM> GetUpdateModelAsync(int id)
        {
            var ourService = await _ourServiceRepository.GetAsync(id);
            var model = new OurServiceUpdateVM
            {
                Title = ourService.Title,
            };
            return model;
        }

        public async Task<bool> UpdateAsync(OurServiceUpdateVM model)
        {
            if (!_modelState.IsValid) return false;
            var isExist = await _ourServiceRepository.AnyAsync(os => os.Title.Trim().ToLower() == model.Title.Trim().ToLower()
            && model.Id != os.Id);
            if (isExist)
            {
                _modelState.AddModelError("Title", "This content already created");
                return false;
            }
            var ourservice = await _ourServiceRepository.GetAsync(model.Id);
            ourservice.Title = model.Title;
            ourservice.ModifiedAt = DateTime.Now;
            if (model.Icon != null)
            {
                int maxSize = 6000;
                if (!_fileService.CheckPhoto(model.Icon))
                {
                    _modelState.AddModelError("Icon", $"File must be Image");
                    return false;
                }

                else if (!_fileService.MaxSize(model.Icon, maxSize))
                {
                    _modelState.AddModelError("Icon", $"Photo size must be less{maxSize} ");
                    return false;
                }

                _fileService.Delete(ourservice.Icon);
                ourservice.Icon = await _fileService.UploadAsync(model.Icon);
            }
            await _ourServiceRepository.UpdateAsync(ourservice);
            return true;
        }
    }
}
