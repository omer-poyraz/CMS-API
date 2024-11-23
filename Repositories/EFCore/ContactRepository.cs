using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(RepositoryContext context) : base(context)
        {
        }

        public Contact CreateContact(Contact contact)
        {
            Create(contact);
            return contact;
        }

        public Contact DeleteContact(Contact contact)
        {
            Delete(contact);
            return contact;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync(bool trackChanges) => await FindAll(trackChanges)
            .OrderBy(s=>s.ContactID)
            .Include(s=>s.User)
            .Include(s=>s.SocialMedia)
            .Include(s=>s.Dealers)
            .ToListAsync();

        public async Task<Contact> GetContactByIdAsync(int id, bool trackChanges) => await FindByCondition(s => s.ContactID.Equals(id), trackChanges)
            .Include(s=>s.User)
            .Include(s=>s.SocialMedia)
            .Include(s=>s.Dealers)
            .SingleOrDefaultAsync();

        public Contact UpdateContact(Contact contact)
        {
            Update(contact);
            return contact;
        }
    }
}
