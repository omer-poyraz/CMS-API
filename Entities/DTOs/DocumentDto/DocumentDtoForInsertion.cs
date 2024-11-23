namespace Entities.DTOs.DocumentDto
{
    public record DocumentDtoForInsertion : DocumentDtoForManipulation
    {
        public DateTime CreateAt { get; init; }
        public DocumentDtoForInsertion()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
