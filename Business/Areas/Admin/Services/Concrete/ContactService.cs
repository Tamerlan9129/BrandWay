using Business.Areas.Admin.Services.Asbract;
using Business.Areas.Admin.ViewModels.Contact;
using Core.Entities;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Business.Areas.Admin.Services.Concrete
{
    public class ContactService : IContactService
    {
        private readonly ModelStateDictionary _modelState;
        private readonly IContactRepository _contactRepository;

        public ContactService(IActionContextAccessor actionContextAccessor,
            IContactRepository contactRepository)
        {
            _modelState = actionContextAccessor.ActionContext.ModelState;
            _contactRepository = contactRepository;
        }
        public async Task<bool> CreateAsync(ContactCreateVM model)
        {
            if (!_modelState.IsValid) return false;
            var contact = new Contact
            {
                Address = model.Address,
                CreatedAt = DateTime.Now,
                EmailAddress = model.EmailAddress,
                PhoneNumber = model.PhoneNumber,
                Careers = model.Careers,
                MondayToSaturday = model.MondayToSaturday,
                Sundays = model.Sundays,
            };
            await _contactRepository.CreateAsync(contact);
            return true;

        }

        public async Task DeleteAsync()
        {
            var contact = await _contactRepository.GetAsync();
            await _contactRepository.DeleteAsync(contact);
        }

        public async Task<ContactIndexVM> GetAsync()
        {
            var contact = await _contactRepository.GetAsync();
            if (contact != null)
            {
                var model = new ContactIndexVM
                {
                    Address = contact.Address,
                    EmailAddress = contact.EmailAddress,
                    Id = contact.Id,
                    PhoneNumber = contact.PhoneNumber,
                    Careers = contact.Careers,
                    MondayToSaturday = contact.MondayToSaturday,
                    Sundays = contact.Sundays,
                    CreatedAt = contact.CreatedAt,
                    ModifiedAt = contact.ModifiedAt,
                };
                return model;
            }
            return null;
        }

        public async Task<ContactUpdateVM> GetUpdateModelAsync()
        {
            var contact = await _contactRepository.GetAsync();
            var model = new ContactUpdateVM
            {
                Address = contact.Address,
                EmailAddress = contact.EmailAddress,
                PhoneNumber = contact.PhoneNumber,
                Careers = contact.Careers,
                MondayToSaturday = contact.MondayToSaturday,
                Sundays = contact.Sundays,

            };
            return model;
        }

        public async Task<bool> UpdateAsync(ContactUpdateVM model)
        {
            if (!_modelState.IsValid) return false;
            var contact = await _contactRepository.GetAsync();
            contact.Address = model.Address;
            contact.PhoneNumber = model.PhoneNumber;
            contact.EmailAddress = model.EmailAddress;
            contact.Careers = model.Careers;
            contact.MondayToSaturday = model.MondayToSaturday;
            contact.Sundays = model.Sundays;
            contact.ModifiedAt = DateTime.Now;
            await _contactRepository.UpdateAsync(contact);
            return true;
        }
    }
}
