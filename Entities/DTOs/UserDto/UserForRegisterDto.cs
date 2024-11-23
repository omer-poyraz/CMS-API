namespace Entities.DTOs.UserDto
{
    public record UserForRegisterDto
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? UserName { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Password { get; init; }
        public ICollection<string>? Roles { get; init; }
        public DateTime CreateAt { get; init; } = DateTime.UtcNow;

        public UserForRegisterDto()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
