using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.UserDto
{
    public abstract record UserDtoForManipulation
    {
        [MaxLength(20)]
        public string? FirstName { get; init; }

        [MaxLength(20)]
        public string? LastName { get; init; }

        [MaxLength(20)]
        public string? UserName { get; init; }

        [MaxLength(30)]
        public string? Email { get; init; }

        [MaxLength(20)]
        public string? PhoneNumber { get; init; }
    }
}
