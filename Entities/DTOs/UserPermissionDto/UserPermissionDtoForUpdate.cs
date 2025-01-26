namespace Entities.DTOs.UserPermissionDto
{
    public record UserPermissionDtoForUpdate : UserPermissionDtoForManipulation
    {
        public int ID { get; init; }
        public DateTime? updated_at { get; init; } = DateTime.UtcNow;
    }
}
