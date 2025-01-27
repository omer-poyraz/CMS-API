using Entities.Models;

namespace Repositories.Contracts
{
    public interface IBlogRepository : IRepositoryBase<Blog>
    {
        Task<IEnumerable<Blog>> GetAllBlogsAsync(bool trackChanges);
        Task<Blog> GetBlogByIdAsync(int id, bool trackChanges);
        Task<Blog> GetBlogBySlugAsync(string slug, bool trackChanges);
        Blog CreateBlog(Blog blog);
        Blog UpdateBlog(Blog blog);
        Blog DeleteBlog(Blog blog);
    }
}
