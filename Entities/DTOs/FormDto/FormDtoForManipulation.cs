namespace Entities.DTOs.FormDto
{
    public abstract record FormDtoForManipulation
    {
        public int FormID { get; init; }
        public string? Title { get; init; }
        public string? TitleEN { get; init; }
        public string? Description { get; init; }
        public string? DescriptionEN { get; init; }
        public string? UserId { get; init; }
    }
}
