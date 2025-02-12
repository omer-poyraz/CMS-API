using AutoMapper;
using Entities.DTOs.GalleryDto;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using Services.Extensions;

namespace Services
{
    public class GalleryService : IGalleryService
    {
        private readonly IRepositoryManager _manager;
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public GalleryService(IRepositoryManager manager, IMapper mapper, RepositoryContext context)
        {
            _manager = manager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<GalleryDto> CreateGalleryAsync(
            GalleryDtoForInsertion galleryGroupDtoForInsertion
        )
        {
            var galleryGroup = _mapper.Map<Entities.Models.Gallery>(galleryGroupDtoForInsertion);
            galleryGroup.Slug = galleryGroup.Title.ToSeoUrl();
            galleryGroup.SlugEN = galleryGroup.TitleEN.ToSeoUrl();
            _manager.GalleryRepository.CreateGallery(galleryGroup);
            await _manager.SaveAsync();
            return _mapper.Map<GalleryDto>(galleryGroup);
        }

        public async Task<GalleryDto> DeleteGalleryAsync(int id, bool trackChanges)
        {
            var galleryGroup = await _manager.GalleryRepository.GetGalleryByIdAsync(
                id,
                trackChanges
            );
            _manager.GalleryRepository.DeleteGallery(galleryGroup);
            await _manager.SaveAsync();
            return _mapper.Map<GalleryDto>(galleryGroup);
        }

        public async Task<IEnumerable<GalleryDto>> GetAllGalleriesAsync(bool trackChanges)
        {
            var galleryGroup = await _manager.GalleryRepository.GetAllGalleriesAsync(trackChanges);
            return _mapper.Map<IEnumerable<GalleryDto>>(galleryGroup);
        }

        public async Task<GalleryDto> GetGalleryByIdAsync(int id, bool trackChanges)
        {
            var galleryGroup = await _manager.GalleryRepository.GetGalleryByIdAsync(
                id,
                trackChanges
            );
            return _mapper.Map<GalleryDto>(galleryGroup);
        }

        public async Task<GalleryDto> GetGalleryBySlugAsync(string slug, bool trackChanges)
        {
            var galleryGroup = await _manager.GalleryRepository.GetGalleryBySlugAsync(
                slug,
                trackChanges
            );
            return _mapper.Map<GalleryDto>(galleryGroup);
        }

        public async Task<GalleryDto> UpdateGalleryAsync(
            int id,
            GalleryDtoForUpdate galleryGroupDtoForUpdate,
            bool trackChanges
        )
        {
            var galleryGroup = await _manager.GalleryRepository.GetGalleryByIdAsync(
                id,
                trackChanges
            );
            var newFiles = new List<string>();
            foreach (var file in galleryGroup.files)
            {
                newFiles.Add(file);
            }
            if (galleryGroupDtoForUpdate.files.Count() > 0)
            {
                foreach (var file in galleryGroupDtoForUpdate.files)
                {
                    newFiles.Add(file);
                }
            }
            galleryGroup.files = newFiles;
            galleryGroup.Slug = galleryGroupDtoForUpdate.Title.ToSeoUrl();
            galleryGroup.SlugEN = galleryGroupDtoForUpdate.TitleEN.ToSeoUrl();
            galleryGroup = _mapper.Map<Entities.Models.Gallery>(galleryGroupDtoForUpdate);
            _manager.GalleryRepository.UpdateGallery(galleryGroup);
            await _manager.SaveAsync();
            return _mapper.Map<GalleryDto>(galleryGroup);
        }
    }
}
