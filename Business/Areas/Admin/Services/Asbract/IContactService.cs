using Business.Areas.Admin.ViewModels.Contact;

namespace Business.Areas.Admin.Services.Asbract
{
    public interface IContactService
    {
        Task<ContactIndexVM> GetAsync();
        Task<bool> CreateAsync(ContactCreateVM model);
        Task<ContactUpdateVM> GetUpdateModelAsync();
        Task<bool> UpdateAsync(ContactUpdateVM model);
        Task DeleteAsync();
    }
}
