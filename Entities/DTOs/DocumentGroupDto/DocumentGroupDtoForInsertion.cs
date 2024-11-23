namespace Entities.DTOs.DocumentGroupDto
{
    public record DocumentGroupDtoForInsertion : DocumentGroupDtoForManipulation
    {
        public DateTime CreateAt { get; init; }
        public DocumentGroupDtoForInsertion()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
