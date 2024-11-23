using AutoMapper;
using Entities.DTOs.FormDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class FormService : IFormService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public FormService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<FormDto> CreateFormAsync(FormDtoForInsertion formDtoForInsertion)
        {
            var form = _mapper.Map<Form>(formDtoForInsertion);
            _manager.FormRepository.CreateForm(form);
            await _manager.SaveAsync();
            return _mapper.Map<FormDto>(form);
        }

        public async Task<FormDto> DeleteFormAsync(int id, bool trackChanges)
        {
            var form = await _manager.FormRepository.GetFormByIdAsync(id, trackChanges);
            _manager.FormRepository.DeleteForm(form);
            await _manager.SaveAsync();
            return _mapper.Map<FormDto>(form);
        }

        public async Task<IEnumerable<FormDto>> GetAllFormsAsync(bool trackChanges)
        {
            var form = await _manager.FormRepository.GetAllFormsAsync(trackChanges);
            return _mapper.Map<IEnumerable<FormDto>>(form);
        }

        public async Task<FormDto> GetFormByIdAsync(int id, bool trackChanges)
        {
            var form = await _manager.FormRepository.GetFormByIdAsync(id, trackChanges);
            return _mapper.Map<FormDto>(form);
        }

        public async Task<FormDto> UpdateFormAsync(int id, FormDtoForUpdate formDtoForUpdate, bool trackChanges)
        {
            var form = await _manager.FormRepository.GetFormByIdAsync(id, trackChanges);
            form = _mapper.Map<Form>(formDtoForUpdate);
            _manager.FormRepository.UpdateForm(form);
            await _manager.SaveAsync();
            return _mapper.Map<FormDto>(form);
        }
    }
}
