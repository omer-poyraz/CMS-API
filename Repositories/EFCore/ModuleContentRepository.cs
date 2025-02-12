using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class ModuleContentRepository : RepositoryBase<ModuleContent>, IModuleContentRepository
    {
        public ModuleContentRepository(RepositoryContext context)
            : base(context) { }

        public ModuleContent CreateModuleContent(ModuleContent moduleContent)
        {
            Create(moduleContent);
            return moduleContent;
        }

        public ModuleContent DeleteModuleContent(ModuleContent moduleContent)
        {
            Delete(moduleContent);
            return moduleContent;
        }

        public async Task<IEnumerable<ModuleContent>> GetAllModuleContentsAsync(
            bool trackChanges
        ) =>
            await FindAll(trackChanges)
                .OrderBy(s => s.ID)
                .Include(s => s.User)
                .Include(s => s.ModuleField)
                .ToListAsync();

        public async Task<ModuleContent> GetModuleContentByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .Include(s => s.ModuleField)
                .SingleOrDefaultAsync();

        public async Task<ModuleContent> GetModuleContentBySlugAsync(
            string slug,
            bool trackChanges
        ) =>
            await FindByCondition(m => m.Slug.Values.Any(v => v == slug), trackChanges)
                .Include(s => s.User)
                .Include(s => s.ModuleField)
                .SingleOrDefaultAsync();

        public async Task<ModuleContent> SortModuleContentAsync(int id, int sort, bool trackChanges)
        {
            var moduleContent = await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .SingleOrDefaultAsync();

            if (moduleContent == null)
                return null;

            var existingModuleContentAtSort = await FindByCondition(
                    s => s.Sort.Equals(sort),
                    trackChanges
                )
                .SingleOrDefaultAsync();

            if (existingModuleContentAtSort != null)
            {
                var tempSort = moduleContent.Sort;
                moduleContent.Sort = sort;
                existingModuleContentAtSort.Sort = tempSort;

                Update(existingModuleContentAtSort);
            }
            else
            {
                moduleContent.Sort = sort;
            }

            Update(moduleContent);
            return moduleContent;
        }

        public ModuleContent UpdateModuleContent(ModuleContent moduleContent)
        {
            Update(moduleContent);
            return moduleContent;
        }
    }
}
