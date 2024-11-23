using AutoMapper;
using Entities.DTOs.ContactDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ContactService : IContactService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public ContactService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ContactDto> CreateContactAsync(ContactDtoForInsertion contactDtoForInsertion)
        {
            var contact = _mapper.Map<Contact>(contactDtoForInsertion);
            _manager.ContactRepository.CreateContact(contact);
            await _manager.SaveAsync();
            return _mapper.Map<ContactDto>(contact);
        }

        public async Task<ContactDto> DeleteContactAsync(int id, bool trackChanges)
        {
            var contact = await _manager.ContactRepository.GetContactByIdAsync(id, trackChanges);
            _manager.ContactRepository.DeleteContact(contact);
            await _manager.SaveAsync();
            return _mapper.Map<ContactDto>(contact);
        }

        public async Task<IEnumerable<ContactDto>> GetAllContactsAsync(bool trackChanges)
        {
            var contact = await _manager.ContactRepository.GetAllContactsAsync(trackChanges);
            return _mapper.Map<IEnumerable<ContactDto>>(contact);
        }

        public async Task<ContactDto> GetContactByIdAsync(int id, bool trackChanges)
        {
            var contact = await _manager.ContactRepository.GetContactByIdAsync(id, trackChanges);
            return _mapper.Map<ContactDto>(contact);
        }

        public async Task<ContactDto> UpdateContactAsync(int id, ContactDtoForUpdate contactDtoForUpdate, bool trackChanges)
        {
            var contact = await _manager.ContactRepository.GetContactByIdAsync(id, trackChanges);
            contact = _mapper.Map<Contact>(contactDtoForUpdate);
            _manager.ContactRepository.UpdateContact(contact);
            await _manager.SaveAsync();
            return _mapper.Map<ContactDto>(contact);
        }
    }
}
