namespace Entities.DTOs.SocialDto
{
    public record SocialDtoForUpdate : SocialDtoForManipulation
    {
        public int SocialID { get; init; }
        public DateTime UpdateAt { get; init; }
        public SocialDtoForUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
