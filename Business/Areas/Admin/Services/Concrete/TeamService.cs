using Business.Areas.Admin.Services.Asbract;
using Business.Areas.Admin.ViewModels.Team;
using Business.Areas.Admin.ViewModels.Testimonial;
using Core.Entities;
using Core.Utilities.FileService;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Business.Areas.Admin.Services.Concrete
{
    public class TeamService : ITeamService
    {
        private readonly ModelStateDictionary _modelState;
        private readonly ITeamRepository _teamRepository;
        private readonly IFileService _fileService;

        public TeamService(IActionContextAccessor actionContextAccessor,
            ITeamRepository teamRepository,
            IFileService fileService)
        {
            _modelState = actionContextAccessor.ActionContext.ModelState;
            _teamRepository = teamRepository;
            _fileService = fileService;
        }
        public async Task<bool> CreateAsync(TeamCreateVM model)
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

            var team = new Team
            {
                CreatedAt = DateTime.Now,
                FullName = model.FullName,
                PhotoName = await _fileService.UploadAsync(model.Photo),
                Position = model.Position,
            };
            await _teamRepository.CreateAsync(team);
            return true;

        }

        public async Task DeleteAsync(int id)
        {
            var testimonial = await _teamRepository.GetAsync(id);
            await _teamRepository.DeleteAsync(testimonial);
        }

        public async Task<TeamIndexVM> GetAllAsync()
        {
            var teams = await _teamRepository.GetAllAsync();
            var model = new TeamIndexVM
            {
                Teams = teams
            };
            return model;
        }

        public async Task<TeamUpdateVM> GetUpdateModelAsync(int id)
        {
            var team = await _teamRepository.GetAsync(id);
            var model = new TeamUpdateVM
            {
                Id = team.Id,
                FullName = team.FullName,
                Position = team.Position,
            };
            return model;
        }

        public async Task<bool> UpdateAsync(TeamUpdateVM model)
        {
            if (!_modelState.IsValid) return false;
           
            var team = await _teamRepository.GetAsync(model.Id);
            team.FullName = model.FullName;
            team.ModifiedAt = DateTime.Now;
            team.Position = model.Position;
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
                _fileService.Delete(team.PhotoName);
                team.PhotoName = await _fileService.UploadAsync(model.Photo);
            }
            await _teamRepository.UpdateAsync(team);
            return true;
        }
    }
}

