namespace Entities.DTOs.ServicesDto
{
    public record ServicesDtoForInsertion : ServicesDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
