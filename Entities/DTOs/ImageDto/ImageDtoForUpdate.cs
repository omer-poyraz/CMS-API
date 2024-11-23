namespace Entities.DTOs.ImageDto
{
    public record ImageDtoForUpdate : ImageDtoForManipulation
    {
        public int ImageID { get; init; }
        public DateTime UpdateAt { get; init; }
        public ImageDtoForUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
