namespace Entities.DTOs.UserPermissionDto
{
    public record UserPermissionDtoForInsertion : UserPermissionDtoForManipulation
    {
        public DateTime? created_at { get; init; } = DateTime.UtcNow;
    }
}
