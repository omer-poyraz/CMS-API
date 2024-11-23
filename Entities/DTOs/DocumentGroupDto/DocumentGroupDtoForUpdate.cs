namespace Entities.DTOs.DocumentGroupDto
{
    public record DocumentGroupDtoForUpdate : DocumentGroupDtoForManipulation
    {
        public int DocumentGroupID { get; init; }
        public DateTime UpdateAt { get; init; }
        public DocumentGroupDtoForUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
