using AutoMapper;
using Entities.DTOs.SettingsDto;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;

namespace Services
{
    public class SettingsService : ISettingsService
    {
        private readonly IRepositoryManager _manager;
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public SettingsService(IRepositoryManager manager, IMapper mapper, RepositoryContext context)
        {
            _manager = manager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<SettingsDto> CreateSettingsAsync(SettingsDtoForInsertion settingsGroupDtoForInsertion)
        {
            var settingsGroup = _mapper.Map<Entities.Models.Settings>(settingsGroupDtoForInsertion);
            _manager.SettingsRepository.CreateSettings(settingsGroup);
            await _manager.SaveAsync();
            return _mapper.Map<SettingsDto>(settingsGroup);
        }

        public async Task<SettingsDto> DeleteSettingsAsync(int id, bool trackChanges)
        {
            var settingsGroup = await _manager.SettingsRepository.GetSettingsByIdAsync(id, trackChanges);
            _manager.SettingsRepository.DeleteSettings(settingsGroup);
            await _manager.SaveAsync();
            return _mapper.Map<SettingsDto>(settingsGroup);
        }

        public async Task<IEnumerable<SettingsDto>> GetAllSettingsAsync(bool trackChanges)
        {
            var settingsGroup = await _manager.SettingsRepository.GetAllSettingsAsync(trackChanges);
            return _mapper.Map<IEnumerable<SettingsDto>>(settingsGroup);
        }

        public async Task<SettingsDto> GetSettingsByIdAsync(int id, bool trackChanges)
        {
            var settingsGroup = await _manager.SettingsRepository.GetSettingsByIdAsync(id, trackChanges);
            return _mapper.Map<SettingsDto>(settingsGroup);
        }

        public async Task<SettingsDto> GetSettingsBySiteAsync(string site, bool trackChanges)
        {
            var settingsGroup = await _manager.SettingsRepository.GetSettingsBySiteAsync(site, trackChanges);
            return _mapper.Map<SettingsDto>(settingsGroup);
        }

        public async Task<SettingsDto> UpdateSettingsAsync(
            int id,
            SettingsDtoForUpdate settingsGroupDtoForUpdate,
            bool trackChanges
        )
        {
            var settingsGroup = await _manager.SettingsRepository.GetSettingsByIdAsync(id, trackChanges);
            var newFiles = new List<string>();
            foreach (var file in settingsGroup.Files)
            {
                newFiles.Add(file);
            }
            if (settingsGroupDtoForUpdate.Files.Count() > 0)
            {
                foreach (var file in settingsGroupDtoForUpdate.Files)
                {
                    newFiles.Add(file);
                }
            }
            settingsGroup.Files = newFiles;
            settingsGroup = _mapper.Map<Entities.Models.Settings>(settingsGroupDtoForUpdate);
            _manager.SettingsRepository.UpdateSettings(settingsGroup);
            await _manager.SaveAsync();
            return _mapper.Map<SettingsDto>(settingsGroup);
        }
    }
}
