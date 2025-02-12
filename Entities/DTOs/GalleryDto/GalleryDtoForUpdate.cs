namespace Entities.DTOs.GalleryDto
{
    public record GalleryDtoForUpdate : GalleryDtoForManipulation
    {
        public int ID { get; init; }
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
