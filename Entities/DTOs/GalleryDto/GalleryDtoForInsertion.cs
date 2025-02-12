namespace Entities.DTOs.GalleryDto
{
    public record GalleryDtoForInsertion : GalleryDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
