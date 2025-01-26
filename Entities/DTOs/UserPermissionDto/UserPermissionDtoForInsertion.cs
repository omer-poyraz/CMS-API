namespace Entities.DTOs.UserPermissionDto
{
    public record UserPermissionDtoForInsertion : UserPermissionDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
