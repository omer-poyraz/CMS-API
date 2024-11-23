using AutoMapper;
using Entities.DTOs.DocumentDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public DocumentService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<DocumentDto> CreateDocumentAsync(DocumentDtoForInsertion documentDtoForInsertion)
        {
            var document = _mapper.Map<Document>(documentDtoForInsertion);
            _manager.DocumentRepository.CreateDocument(document);
            await _manager.SaveAsync();
            return _mapper.Map<DocumentDto>(document);
        }

        public async Task<DocumentDto> DeleteDocumentAsync(int id, bool trackChanges)
        {
            var document = await _manager.DocumentRepository.GetDocumentByIdAsync(id, trackChanges);
            _manager.DocumentRepository.DeleteDocument(document);
            await _manager.SaveAsync();
            return _mapper.Map<DocumentDto>(document);
        }

        public async Task<IEnumerable<DocumentDto>> GetAllDocumentsAsync(bool trackChanges)
        {
            var document = await _manager.DocumentRepository.GetAllDocumentsAsync(trackChanges);
            return _mapper.Map<IEnumerable<DocumentDto>>(document);
        }

        public async Task<IEnumerable<DocumentDto>> GetAllDocumentsByGroupAsync(int id, bool trackChanges)
        {
            var document = await _manager.DocumentRepository.GetAllDocumentsByGroupAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<DocumentDto>>(document);
        }

        public async Task<DocumentDto> GetDocumentByIdAsync(int id, bool trackChanges)
        {
            var document = await _manager.DocumentRepository.GetDocumentByIdAsync(id, trackChanges);
            return _mapper.Map<DocumentDto>(document);
        }

        public async Task<DocumentDto> UpdateDocumentAsync(int id, DocumentDtoForUpdate documentDtoForUpdate, bool trackChanges)
        {
            var document = await _manager.DocumentRepository.GetDocumentByIdAsync(id, trackChanges);
            document = _mapper.Map<Document>(documentDtoForUpdate);
            _manager.DocumentRepository.UpdateDocument(document);
            await _manager.SaveAsync();
            return _mapper.Map<DocumentDto>(document);
        }
    }
}
