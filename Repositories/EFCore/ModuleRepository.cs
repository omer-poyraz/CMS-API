using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class ModuleRepository : RepositoryBase<Module>, IModuleRepository
    {
        public ModuleRepository(RepositoryContext context)
            : base(context) { }

        public Module CreateModule(Module module)
        {
            Create(module);
            return module;
        }

        public Module DeleteModule(Module module)
        {
            Delete(module);
            return module;
        }

        public async Task<IEnumerable<Module>> GetAllModulesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(s => s.ID)
                .Include(s => s.User)
                .Include(s => s.Fields)
                .ToListAsync();

        public async Task<Module> GetModuleByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .Include(s => s.Fields)
                .SingleOrDefaultAsync();

        public async Task<Module> GetModuleBySlugAsync(string slug, bool trackChanges) =>
            await FindByCondition(m => m.Slug.Values.Any(v => v == slug), trackChanges)
                .Include(s => s.User)
                .Include(s => s.Fields)
                .SingleOrDefaultAsync();

        public async Task<Module> SortModuleAsync(int id, int sort, bool trackChanges)
        {
            var module = await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .SingleOrDefaultAsync();

            if (module == null)
                return null;

            var existingModuleAtSort = await FindByCondition(s => s.Sort.Equals(sort), trackChanges)
                .SingleOrDefaultAsync();

            if (existingModuleAtSort != null)
            {
                var tempSort = module.Sort;
                module.Sort = sort;
                existingModuleAtSort.Sort = tempSort;

                Update(existingModuleAtSort);
            }
            else
            {
                module.Sort = sort;
            }

            Update(module);
            return module;
        }

        public Module UpdateModule(Module module)
        {
            Update(module);
            return module;
        }
    }
}
