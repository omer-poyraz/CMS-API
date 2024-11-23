namespace Entities.DTOs.SocialDto
{
    public record SocialDtoForInsertion : SocialDtoForManipulation
    {
        public DateTime CreateAt { get; init; }
        public SocialDtoForInsertion()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
