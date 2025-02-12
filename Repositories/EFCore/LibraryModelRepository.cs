using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class LibraryModelRepository : RepositoryBase<LibraryModel>, ILibraryModelRepository
    {
        public LibraryModelRepository(RepositoryContext context)
            : base(context) { }

        public LibraryModel CreateLibraryModel(LibraryModel libraryModel)
        {
            Create(libraryModel);
            return libraryModel;
        }

        public LibraryModel DeleteLibraryModel(LibraryModel libraryModel)
        {
            Delete(libraryModel);
            return libraryModel;
        }

        public async Task<IEnumerable<LibraryModel>> GetAllLibraryModelsAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(s => s.ID).Include(s => s.User).ToListAsync();

        public async Task<LibraryModel> GetLibraryModelByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();

        public async Task<LibraryModel> GetLibraryModelBySiteAsync(
            string site,
            bool trackChanges
        ) =>
            await FindByCondition(s => s.Site.Equals(site), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();

        public async Task<LibraryModel> GetLibraryModelBySlugAsync(
            string slug,
            bool trackChanges
        ) =>
            await FindByCondition(s => s.Slug.Equals(slug) || s.SlugEN.Equals(slug), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();

        public LibraryModel UpdateLibraryModel(LibraryModel libraryModel)
        {
            Update(libraryModel);
            return libraryModel;
        }
    }
}
