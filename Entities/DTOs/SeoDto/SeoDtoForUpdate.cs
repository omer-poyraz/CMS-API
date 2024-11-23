namespace Entities.DTOs.SeoDto
{
    public record SeoDtoForUpdate : SeoDtoForManipulation
    {
        public int SeoID { get; init; }
        public DateTime UpdateAt { get; init; }
        public SeoDtoForUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
