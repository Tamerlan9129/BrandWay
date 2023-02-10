using Business.Areas.Admin.ViewModels.Team;
using Business.Areas.Admin.ViewModels.Testimonial;

namespace Business.Areas.Admin.Services.Asbract
{
    public interface ITeamService
    {
        Task<TeamIndexVM> GetAllAsync();
        Task<bool> CreateAsync(TeamCreateVM model);
        Task<TeamUpdateVM> GetUpdateModelAsync(int id);
        Task<bool> UpdateAsync(TeamUpdateVM model);
        Task DeleteAsync(int id);
    }
}
