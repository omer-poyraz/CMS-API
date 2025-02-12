using AutoMapper;
using Entities.DTOs.ModuleDto;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using Services.Extensions;

namespace Services
{
    public class ModuleService : IModuleService
    {
        private readonly IRepositoryManager _manager;
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public ModuleService(IRepositoryManager manager, IMapper mapper, RepositoryContext context)
        {
            _manager = manager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ModuleDto> CreateModuleAsync(ModuleDtoForInsertion moduleDtoForInsertion)
        {
            var module = _mapper.Map<Entities.Models.Module>(moduleDtoForInsertion);
            _manager.ModuleRepository.CreateModule(module);
            await _manager.SaveAsync();
            return _mapper.Map<ModuleDto>(module);
        }

        public async Task<ModuleDto> DeleteModuleAsync(int id, bool trackChanges)
        {
            var module = await _manager.ModuleRepository.GetModuleByIdAsync(id, trackChanges);
            _manager.ModuleRepository.DeleteModule(module);
            await _manager.SaveAsync();
            return _mapper.Map<ModuleDto>(module);
        }

        public async Task<IEnumerable<ModuleDto>> GetAllModulesAsync(bool trackChanges)
        {
            var module = await _manager.ModuleRepository.GetAllModulesAsync(trackChanges);
            return _mapper.Map<IEnumerable<ModuleDto>>(module);
        }

        public async Task<ModuleDto> GetModuleByIdAsync(int id, bool trackChanges)
        {
            var module = await _manager.ModuleRepository.GetModuleByIdAsync(id, trackChanges);
            return _mapper.Map<ModuleDto>(module);
        }

        public async Task<ModuleDto> GetModuleBySlugAsync(string slug, bool trackChanges)
        {
            var module = await _manager.ModuleRepository.GetModuleBySlugAsync(slug, trackChanges);
            return _mapper.Map<ModuleDto>(module);
        }

        public async Task<ModuleDto> SortModuleAsync(int id, int sort, bool trackChanges)
        {
            var module = await _manager.ModuleRepository.SortModuleAsync(id, sort, trackChanges);
            return _mapper.Map<ModuleDto>(module);
        }

        public async Task<ModuleDto> UpdateModuleAsync(
            int id,
            ModuleDtoForUpdate moduleDtoForUpdate,
            bool trackChanges
        )
        {
            var module = await _manager.ModuleRepository.GetModuleByIdAsync(id, trackChanges);
            var newFiles = new List<string>();
            foreach (var file in module.Files)
            {
                newFiles.Add(file);
            }
            if (moduleDtoForUpdate.Files.Count() > 0)
            {
                foreach (var file in moduleDtoForUpdate.Files)
                {
                    newFiles.Add(file);
                }
            }
            module.Files = newFiles;
            _mapper.Map(moduleDtoForUpdate, module);
            _manager.ModuleRepository.UpdateModule(module);
            await _manager.SaveAsync();
            return _mapper.Map<ModuleDto>(module);
        }
    }
}
