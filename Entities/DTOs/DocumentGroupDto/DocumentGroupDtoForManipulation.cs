namespace Entities.DTOs.DocumentGroupDto
{
    public abstract record DocumentGroupDtoForManipulation
    {
        public string? Title { get; init; }
        public string? TitleEN { get; init; }
        public string? Description { get; init; }
        public string? DescriptionEN { get; init; }
        public string? UserId { get; init; }
    }
}
