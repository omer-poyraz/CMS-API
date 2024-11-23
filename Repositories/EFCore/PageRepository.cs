using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class PageRepository : RepositoryBase<Page>, IPageRepository
    {
        public PageRepository(RepositoryContext context)
            : base(context) { }

        public Page CreatePage(Page page)
        {
            Create(page);
            return page;
        }

        public Page DeletePage(Page page)
        {
            Delete(page);
            return page;
        }

        public async Task<IEnumerable<Page>> GetAllPagesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(s => s.PageID)
                .Include(s => s.User)
                .Include(s => s.DocumentGroup)
                .Include(s => s.Seo)
                .Include(s => s.Header)
                .ToListAsync();

        public async Task<Page> GetPageByHeaderIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.HeaderID.Equals(id), trackChanges)
                .Include(s => s.User)
                .Include(s => s.DocumentGroup)
                .Include(s => s.Seo)
                .Include(s => s.Header)
                .SingleOrDefaultAsync();

        public async Task<Page> GetPageByHeaderURLAsync(string url, bool trackChanges) =>
            await FindByCondition(
                    s =>
                        (
                            s.Header.UrlTR.Contains(url)
                            || s.Header.UrlEN.Contains(url)
                            || s.Header.UrlAR.Contains(url)
                            || s.Header.UrlFR.Contains(url)
                        ),
                    trackChanges
                )
                .Include(s => s.User)
                .Include(s => s.DocumentGroup)
                .Include(s => s.Seo)
                .Include(s => s.Header)
                .SingleOrDefaultAsync();

        public async Task<Page> GetPageByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.PageID.Equals(id), trackChanges)
                .Include(s => s.User)
                .Include(s => s.DocumentGroup)
                .Include(s => s.Seo)
                .Include(s => s.Header)
                .SingleOrDefaultAsync();

        public Page UpdatePage(Page page)
        {
            Update(page);
            return page;
        }
    }
}
