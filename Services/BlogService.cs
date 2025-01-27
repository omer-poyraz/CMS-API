using AutoMapper;
using Entities.DTOs.BlogDto;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using Services.Extensions;

namespace Services
{
    public class BlogService : IBlogService
    {
        private readonly IRepositoryManager _manager;
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public BlogService(IRepositoryManager manager, IMapper mapper, RepositoryContext context)
        {
            _manager = manager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<BlogDto> CreateBlogAsync(BlogDtoForInsertion blogGroupDtoForInsertion)
        {
            var blogGroup = _mapper.Map<Entities.Models.Blog>(blogGroupDtoForInsertion);
            blogGroup.Slug = blogGroup.Title.ToSeoUrl();
            blogGroup.SlugEN = blogGroup.TitleEN.ToSeoUrl();
            _manager.BlogRepository.CreateBlog(blogGroup);
            await _manager.SaveAsync();
            return _mapper.Map<BlogDto>(blogGroup);
        }

        public async Task<BlogDto> DeleteBlogAsync(int id, bool trackChanges)
        {
            var blogGroup = await _manager.BlogRepository.GetBlogByIdAsync(id, trackChanges);
            _manager.BlogRepository.DeleteBlog(blogGroup);
            await _manager.SaveAsync();
            return _mapper.Map<BlogDto>(blogGroup);
        }

        public async Task<IEnumerable<BlogDto>> GetAllBlogsAsync(bool trackChanges)
        {
            var blogGroup = await _manager.BlogRepository.GetAllBlogsAsync(trackChanges);
            return _mapper.Map<IEnumerable<BlogDto>>(blogGroup);
        }

        public async Task<BlogDto> GetBlogByIdAsync(int id, bool trackChanges)
        {
            var blogGroup = await _manager.BlogRepository.GetBlogByIdAsync(id, trackChanges);
            return _mapper.Map<BlogDto>(blogGroup);
        }

        public async Task<BlogDto> GetBlogBySlugAsync(string slug, bool trackChanges)
        {
            var blogGroup = await _manager.BlogRepository.GetBlogBySlugAsync(slug, trackChanges);
            return _mapper.Map<BlogDto>(blogGroup);
        }

        public async Task<BlogDto> UpdateBlogAsync(
            int id,
            BlogDtoForUpdate blogGroupDtoForUpdate,
            bool trackChanges
        )
        {
            var blogGroup = await _manager.BlogRepository.GetBlogByIdAsync(id, trackChanges);
            blogGroup = _mapper.Map<Entities.Models.Blog>(blogGroupDtoForUpdate);
            blogGroup.Slug = blogGroup.Title.ToSeoUrl();
            blogGroup.SlugEN = blogGroup.TitleEN.ToSeoUrl();
            _manager.BlogRepository.UpdateBlog(blogGroup);
            await _manager.SaveAsync();
            return _mapper.Map<BlogDto>(blogGroup);
        }
    }
}
