using Entities.DTOs.BlogDto;

namespace Services.Contracts
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogDto>> GetAllBlogsAsync(bool trackChanges);
        Task<BlogDto> GetBlogByIdAsync(int id, bool trackChanges);
        Task<BlogDto> GetBlogBySlugAsync(string slug, bool trackChanges);
        Task<BlogDto> CreateBlogAsync(BlogDtoForInsertion blogDtoForInsertion);
        Task<BlogDto> UpdateBlogAsync(int id, BlogDtoForUpdate blogDtoForUpdate, bool trackChanges);
        Task<BlogDto> DeleteBlogAsync(int id, bool trackChanges);
    }
}
