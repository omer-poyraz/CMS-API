namespace Entities.DTOs.FilesDto
{
    public record FilesDtoForInsertion : FilesDtoForManipulation
    {
        public DateTime CreateAt { get; init; }
        public FilesDtoForInsertion()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
