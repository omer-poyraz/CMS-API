namespace Entities.DTOs.FilesDto
{
    public record FilesDtoForUpdate : FilesDtoForManipulation
    {
        public int FilesID { get; init; }
        public DateTime UpdateAt { get; init; }
        public FilesDtoForUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
