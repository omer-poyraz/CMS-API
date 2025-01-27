using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class BlogRepository : RepositoryBase<Blog>, IBlogRepository
    {
        public BlogRepository(RepositoryContext context)
            : base(context) { }

        public Blog CreateBlog(Blog blog)
        {
            Create(blog);
            return blog;
        }

        public Blog DeleteBlog(Blog blog)
        {
            Delete(blog);
            return blog;
        }

        public async Task<IEnumerable<Blog>> GetAllBlogsAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(s => s.ID).Include(s => s.User).ToListAsync();

        public async Task<Blog> GetBlogByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();

        public async Task<Blog> GetBlogBySlugAsync(string slug, bool trackChanges) =>
            await FindByCondition(s => s.Slug.Equals(slug) || s.SlugEN.Equals(slug), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();

        public Blog UpdateBlog(Blog blog)
        {
            Update(blog);
            return blog;
        }
    }
}
