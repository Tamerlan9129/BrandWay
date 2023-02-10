using Business.ViewModels.Contact;

namespace Business.Services.Abstract
{
    public interface IContactService
    {
        Task<ContactIndexVM> GetAllAsync();
    }
}
