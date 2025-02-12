using AutoMapper;
using Entities.DTOs.LibraryModelDto;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using Services.Extensions;

namespace Services
{
    public class LibraryModelService : ILibraryModelService
    {
        private readonly IRepositoryManager _manager;
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public LibraryModelService(
            IRepositoryManager manager,
            IMapper mapper,
            RepositoryContext context
        )
        {
            _manager = manager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<LibraryModelDto> CreateLibraryModelAsync(
            LibraryModelDtoForInsertion libraryModelGroupDtoForInsertion
        )
        {
            var libraryModelGroup = _mapper.Map<Entities.Models.LibraryModel>(
                libraryModelGroupDtoForInsertion
            );
            libraryModelGroup.Slug = libraryModelGroup.Title.ToSeoUrl();
            libraryModelGroup.SlugEN = libraryModelGroup.TitleEN.ToSeoUrl();
            _manager.LibraryModelRepository.CreateLibraryModel(libraryModelGroup);
            await _manager.SaveAsync();
            return _mapper.Map<LibraryModelDto>(libraryModelGroup);
        }

        public async Task<LibraryModelDto> DeleteLibraryModelAsync(int id, bool trackChanges)
        {
            var libraryModelGroup = await _manager.LibraryModelRepository.GetLibraryModelByIdAsync(
                id,
                trackChanges
            );
            _manager.LibraryModelRepository.DeleteLibraryModel(libraryModelGroup);
            await _manager.SaveAsync();
            return _mapper.Map<LibraryModelDto>(libraryModelGroup);
        }

        public async Task<IEnumerable<LibraryModelDto>> GetAllLibraryModelsAsync(bool trackChanges)
        {
            var libraryModelGroup = await _manager.LibraryModelRepository.GetAllLibraryModelsAsync(
                trackChanges
            );
            return _mapper.Map<IEnumerable<LibraryModelDto>>(libraryModelGroup);
        }

        public async Task<LibraryModelDto> GetLibraryModelByIdAsync(int id, bool trackChanges)
        {
            var libraryModelGroup = await _manager.LibraryModelRepository.GetLibraryModelByIdAsync(
                id,
                trackChanges
            );
            return _mapper.Map<LibraryModelDto>(libraryModelGroup);
        }

        public async Task<LibraryModelDto> GetLibraryModelBySiteAsync(
            string site,
            bool trackChanges
        )
        {
            var libraryModelGroup =
                await _manager.LibraryModelRepository.GetLibraryModelBySiteAsync(
                    site,
                    trackChanges
                );
            return _mapper.Map<LibraryModelDto>(libraryModelGroup);
        }

        public async Task<LibraryModelDto> GetLibraryModelBySlugAsync(
            string slug,
            bool trackChanges
        )
        {
            var libraryModelGroup =
                await _manager.LibraryModelRepository.GetLibraryModelBySlugAsync(
                    slug,
                    trackChanges
                );
            return _mapper.Map<LibraryModelDto>(libraryModelGroup);
        }

        public async Task<LibraryModelDto> UpdateLibraryModelAsync(
            int id,
            LibraryModelDtoForUpdate libraryModelGroupDtoForUpdate,
            bool trackChanges
        )
        {
            var libraryModelGroup = await _manager.LibraryModelRepository.GetLibraryModelByIdAsync(
                id,
                trackChanges
            );
            libraryModelGroup.File =
                libraryModelGroupDtoForUpdate.File != null
                    ? libraryModelGroupDtoForUpdate.Title
                    : libraryModelGroup.File;
            libraryModelGroup.Slug = libraryModelGroupDtoForUpdate.Title.ToSeoUrl();
            libraryModelGroup.SlugEN = libraryModelGroupDtoForUpdate.TitleEN.ToSeoUrl();
            libraryModelGroup = _mapper.Map<Entities.Models.LibraryModel>(
                libraryModelGroupDtoForUpdate
            );
            _manager.LibraryModelRepository.UpdateLibraryModel(libraryModelGroup);
            await _manager.SaveAsync();
            return _mapper.Map<LibraryModelDto>(libraryModelGroup);
        }
    }
}
