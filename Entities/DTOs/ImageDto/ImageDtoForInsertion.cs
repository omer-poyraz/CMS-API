namespace Entities.DTOs.ImageDto
{
    public record ImageDtoForInsertion : ImageDtoForManipulation
    {
        public DateTime CreateAt { get; init; }
        public ImageDtoForInsertion()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
