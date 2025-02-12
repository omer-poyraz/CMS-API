using AutoMapper;
using Entities.DTOs.ModuleContentDto;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using Services.Extensions;

namespace Services
{
    public class ModuleContentService : IModuleContentService
    {
        private readonly IRepositoryManager _manager;
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public ModuleContentService(
            IRepositoryManager manager,
            IMapper mapper,
            RepositoryContext context
        )
        {
            _manager = manager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ModuleContentDto> CreateModuleContentAsync(
            ModuleContentDtoForInsertion moduleContentDtoForInsertion
        )
        {
            var moduleContent = _mapper.Map<Entities.Models.ModuleContent>(
                moduleContentDtoForInsertion
            );
            _manager.ModuleContentRepository.CreateModuleContent(moduleContent);
            await _manager.SaveAsync();
            return _mapper.Map<ModuleContentDto>(moduleContent);
        }

        public async Task<ModuleContentDto> DeleteModuleContentAsync(int id, bool trackChanges)
        {
            var moduleContent = await _manager.ModuleContentRepository.GetModuleContentByIdAsync(
                id,
                trackChanges
            );
            _manager.ModuleContentRepository.DeleteModuleContent(moduleContent);
            await _manager.SaveAsync();
            return _mapper.Map<ModuleContentDto>(moduleContent);
        }

        public async Task<IEnumerable<ModuleContentDto>> GetAllModuleContentsAsync(
            bool trackChanges
        )
        {
            var moduleContent = await _manager.ModuleContentRepository.GetAllModuleContentsAsync(
                trackChanges
            );
            return _mapper.Map<IEnumerable<ModuleContentDto>>(moduleContent);
        }

        public async Task<ModuleContentDto> GetModuleContentByIdAsync(int id, bool trackChanges)
        {
            var moduleContent = await _manager.ModuleContentRepository.GetModuleContentByIdAsync(
                id,
                trackChanges
            );
            return _mapper.Map<ModuleContentDto>(moduleContent);
        }

        public async Task<ModuleContentDto> GetModuleContentBySlugAsync(
            string slug,
            bool trackChanges
        )
        {
            var moduleContent = await _manager.ModuleContentRepository.GetModuleContentBySlugAsync(
                slug,
                trackChanges
            );
            return _mapper.Map<ModuleContentDto>(moduleContent);
        }

        public async Task<ModuleContentDto> SortModuleContentAsync(
            int id,
            int sort,
            bool trackChanges
        )
        {
            var moduleContent = await _manager.ModuleContentRepository.SortModuleContentAsync(
                id,
                sort,
                trackChanges
            );
            return _mapper.Map<ModuleContentDto>(moduleContent);
        }

        public async Task<ModuleContentDto> UpdateModuleContentAsync(
            int id,
            ModuleContentDtoForUpdate moduleContentDtoForUpdate,
            bool trackChanges
        )
        {
            var moduleContent = await _manager.ModuleContentRepository.GetModuleContentByIdAsync(
                id,
                trackChanges
            );
            var newFiles = new List<string>();
            foreach (var file in moduleContent.Files)
            {
                newFiles.Add(file);
            }
            if (moduleContentDtoForUpdate.Files.Count() > 0)
            {
                foreach (var file in moduleContentDtoForUpdate.Files)
                {
                    newFiles.Add(file);
                }
            }
            moduleContent.Files = newFiles;
            _mapper.Map(moduleContentDtoForUpdate, moduleContent);
            _manager.ModuleContentRepository.UpdateModuleContent(moduleContent);
            await _manager.SaveAsync();
            return _mapper.Map<ModuleContentDto>(moduleContent);
        }
    }
}
