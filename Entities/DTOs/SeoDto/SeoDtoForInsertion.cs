namespace Entities.DTOs.SeoDto
{
    public record SeoDtoForInsertion : SeoDtoForManipulation
    {
        public DateTime CreateAt { get; init; }
        public SeoDtoForInsertion()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
