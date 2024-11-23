namespace Entities.DTOs.FilesGroupDto
{
    public record FilesGroupDtoForUpdate : FilesGroupDtoForManipulation
    {
        public int FilesGroupID { get; init; }
        public DateTime UpdateAt { get; init; }
        public FilesGroupDtoForUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
