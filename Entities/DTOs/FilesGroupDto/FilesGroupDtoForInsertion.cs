namespace Entities.DTOs.FilesGroupDto
{
    public record FilesGroupDtoForInsertion : FilesGroupDtoForManipulation
    {
        public DateTime CreateAt { get; init; }
        public FilesGroupDtoForInsertion()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
