using Microsoft.AspNetCore.Identity;

namespace Entities.DTOs.UserDto
{
    public record UserDto
    {
        public string? UserId { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? UserName { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Gender { get; init; }
        public string? Company { get; init; }
        public string? Phone2 { get; init; }
        public string? Fax { get; init; }
        public string? Address { get; init; }
        public ICollection<IdentityRole>? Roles { get; init; }
        public DateTime CreateAt { get; init; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; init; } = DateTime.UtcNow;
    }
}
