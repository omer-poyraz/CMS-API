using AutoMapper;
using Entities.DTOs.DocumentGroupDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class DocumentGroupService : IDocumentGroupService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public DocumentGroupService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<DocumentGroupDto> CreateDocumentGroupAsync(DocumentGroupDtoForInsertion documentGroupDtoForInsertion)
        {
            var documentGroup = _mapper.Map<DocumentGroup>(documentGroupDtoForInsertion);
            _manager.DocumentGroupRepository.CreateDocumentGroup(documentGroup);
            await _manager.SaveAsync();
            return _mapper.Map<DocumentGroupDto>(documentGroup);
        }

        public async Task<DocumentGroupDto> DeleteDocumentGroupAsync(int id, bool trackChanges)
        {
            var documentGroup = await _manager.DocumentGroupRepository.GetDocumentGroupByIdAsync(id, trackChanges);
            _manager.DocumentGroupRepository.DeleteDocumentGroup(documentGroup);
            await _manager.SaveAsync();
            return _mapper.Map<DocumentGroupDto>(documentGroup);
        }

        public async Task<IEnumerable<DocumentGroupDto>> GetAllDocumentGroupsAsync(bool trackChanges)
        {
            var documentGroup = await _manager.DocumentGroupRepository.GetAllDocumentGroupsAsync(trackChanges);
            return _mapper.Map<IEnumerable<DocumentGroupDto>>(documentGroup);
        }

        public async Task<DocumentGroupDto> GetDocumentGroupByIdAsync(int id, bool trackChanges)
        {
            var documentGroup = await _manager.DocumentGroupRepository.GetDocumentGroupByIdAsync(id, trackChanges);
            return _mapper.Map<DocumentGroupDto>(documentGroup);
        }

        public async Task<DocumentGroupDto> UpdateDocumentGroupAsync(int id, DocumentGroupDtoForUpdate documentGroupDtoForUpdate, bool trackChanges)
        {
            var documentGroup = await _manager.DocumentGroupRepository.GetDocumentGroupByIdAsync(id, trackChanges);
            documentGroup = _mapper.Map<DocumentGroup>(documentGroupDtoForUpdate);
            _manager.DocumentGroupRepository.UpdateDocumentGroup(documentGroup);
            await _manager.SaveAsync();
            return _mapper.Map<DocumentGroupDto>(documentGroup);
        }
    }
}
