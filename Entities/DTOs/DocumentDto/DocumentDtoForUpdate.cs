namespace Entities.DTOs.DocumentDto
{
    public record DocumentDtoForUpdate : DocumentDtoForManipulation
    {
        public int DocumentID { get; init; }
        public DateTime UpdateAt { get; init; }
        public DocumentDtoForUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
