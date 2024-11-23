using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.UserDto
{
    public record UserDtoForUpdate : UserDtoForManipulation
    {
        [Required]
        public string? UserId { get; init; }
        public DateTime UpdateAt { get; init; }
    }
}
