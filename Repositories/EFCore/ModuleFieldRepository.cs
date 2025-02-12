using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class ModuleFieldRepository : RepositoryBase<ModuleField>, IModuleFieldRepository
    {
        public ModuleFieldRepository(RepositoryContext context)
            : base(context) { }

        public ModuleField CreateModuleField(ModuleField moduleField)
        {
            Create(moduleField);
            return moduleField;
        }

        public ModuleField DeleteModuleField(ModuleField moduleField)
        {
            Delete(moduleField);
            return moduleField;
        }

        public async Task<IEnumerable<ModuleField>> GetAllModuleFieldsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(s => s.ID)
                .Include(s => s.User)
                .Include(s => s.Module)
                .ToListAsync();

        public async Task<ModuleField> GetModuleFieldByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .Include(s => s.Module)
                .SingleOrDefaultAsync();

        public async Task<ModuleField> GetModuleFieldBySlugAsync(string slug, bool trackChanges) =>
            await FindByCondition(m => m.Slug.Values.Any(v => v == slug), trackChanges)
                .Include(s => s.User)
                .Include(s => s.Module)
                .SingleOrDefaultAsync();

        public async Task<ModuleField> SortModuleFieldAsync(int id, int sort, bool trackChanges)
        {
            var moduleField = await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .SingleOrDefaultAsync();

            if (moduleField == null)
                return null;

            var existingModuleFieldAtSort = await FindByCondition(
                    s => s.Sort.Equals(sort),
                    trackChanges
                )
                .SingleOrDefaultAsync();

            if (existingModuleFieldAtSort != null)
            {
                var tempSort = moduleField.Sort;
                moduleField.Sort = sort;
                existingModuleFieldAtSort.Sort = tempSort;

                Update(existingModuleFieldAtSort);
            }
            else
            {
                moduleField.Sort = sort;
            }

            Update(moduleField);
            return moduleField;
        }

        public ModuleField UpdateModuleField(ModuleField moduleField)
        {
            Update(moduleField);
            return moduleField;
        }
    }
}
