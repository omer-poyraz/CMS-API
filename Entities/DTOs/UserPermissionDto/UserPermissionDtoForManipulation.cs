using System.Text.Json;
using Entities.Models;

namespace Entities.DTOs.UserPermissionDto
{
    public abstract record UserPermissionDtoForManipulation
    {
        public string? UserId { get; init; }
        public User? User { get; init; }
        public string? ServiceName { get; init; }
        public bool CanRead { get; init; }
        public bool CanWrite { get; init; }
        public bool CanDelete { get; init; }
    }
}
