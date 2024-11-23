using Entities.Models;

namespace Repositories.Contracts
{
    public interface IContactRepository : IRepositoryBase<Contact>
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync(bool trackChanges);
        Task<Contact> GetContactByIdAsync(int id, bool trackChanges);
        Contact CreateContact(Contact contact);
        Contact UpdateContact(Contact contact);
        Contact DeleteContact(Contact contact);
    }
}
