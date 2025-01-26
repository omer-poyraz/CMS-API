using System.Text.Json;
using Entities.Models;

namespace Entities.DTOs.UserPermissionDto
{
    public class UserPermissionDto
    {
        public int ID { get; init; }
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
        public DateTime? created_at { get; init; }
        public DateTime? updated_at { get; init; }
    }
}
