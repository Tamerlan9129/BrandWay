

using Business.Services.Abstract;
using Business.ViewModels.Contact;
using DataAccess.Repositories.Abstract;

namespace Business.Services.Conrete
{
    public class ContactService : IContactService
    {
        private readonly ILocationRepository _locationRepository;

        public ContactService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public async Task<ContactIndexVM> GetAllAsync()
        {
            var model = new ContactIndexVM
            {
                Location = await _locationRepository.GetAsync()
         
            };
            return model;   
        }
    }
}
