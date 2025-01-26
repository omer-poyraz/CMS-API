using System.Text.Json;
using Entities.Models;

namespace Entities.DTOs.UserPermissionDto
{
    public abstract record UserPermissionDtoForManipulation
    {
        public string? userId { get; init; }
        public User? user { get; init; }
        public string? service_name { get; init; }
        public bool can_super_admin { get; init; }
        public bool can_read { get; init; }
        public bool can_write { get; init; }
        public bool can_delete { get; init; }
        public bool can_btk { get; init; }
        public bool can_hosting { get; init; }
        public bool can_consumer { get; init; }
        public bool can_ethernet { get; init; }
    }
}
