using Entities.DTOs.ContactDto;

namespace Services.Contracts
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>> GetAllContactsAsync(bool trackChanges);
        Task<ContactDto> GetContactByIdAsync(int id, bool trackChanges);
        Task<ContactDto> CreateContactAsync(ContactDtoForInsertion contactDtoForInsertion);
        Task<ContactDto> UpdateContactAsync(int id, ContactDtoForUpdate contactDtoForUpdate, bool trackChanges);
        Task<ContactDto> DeleteContactAsync(int id, bool trackChanges);
    }
}
