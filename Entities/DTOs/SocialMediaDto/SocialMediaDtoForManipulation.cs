namespace Entities.DTOs.SocialMediaDto
{
    public abstract record SocialMediaDtoForManipulation
    {
        public string? Title { get; init; }
        public string? TitleEN { get; init; }
        public string? Description { get; init; }
        public string? DescriptionEN { get; init; }
        public string? UserId { get; init; }
    }
}
