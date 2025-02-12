using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class FormElementRepository : RepositoryBase<FormElement>, IFormElementRepository
    {
        public FormElementRepository(RepositoryContext context)
            : base(context) { }

        public FormElement CreateFormElement(FormElement formElement)
        {
            Create(formElement);
            return formElement;
        }

        public FormElement DeleteFormElement(FormElement formElement)
        {
            Delete(formElement);
            return formElement;
        }

        public async Task<IEnumerable<FormElement>> GetAllFormElementsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(s => s.ID)
                .Include(s => s.User)
                .Include(s => s.Form)
                .ToListAsync();

        public async Task<FormElement> GetFormElementByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .Include(s => s.Form)
                .SingleOrDefaultAsync();

        public FormElement UpdateFormElement(FormElement formElement)
        {
            Update(formElement);
            return formElement;
        }
    }
}
