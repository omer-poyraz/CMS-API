namespace Entities.DTOs.ServicesDto
{
    public record ServicesDtoForUpdate : ServicesDtoForManipulation
    {
        public int ID { get; init; }
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
