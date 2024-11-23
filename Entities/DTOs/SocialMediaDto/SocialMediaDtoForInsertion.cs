namespace Entities.DTOs.SocialMediaDto
{
    public record SocialMediaDtoForInsertion : SocialMediaDtoForManipulation
    {
        public DateTime CreateAt { get; init; }
        public SocialMediaDtoForInsertion()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
