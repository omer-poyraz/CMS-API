namespace Entities.DTOs.SocialMediaDto
{
    public record SocialMediaDtoForUpdate : SocialMediaDtoForManipulation
    {
        public int SocialMediaID { get; init; }
        public DateTime UpdateAt { get; init; }
        public SocialMediaDtoForUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
