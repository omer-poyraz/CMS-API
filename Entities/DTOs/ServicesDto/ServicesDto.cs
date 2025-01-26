using System.Text.Json;
using Entities.Models;

namespace Entities.DTOs.ServicesDto
{
    public class ServicesDto
    {
        public int ID { get; init; }
        public string? Name { get; init; }
        public string? EndPoint { get; init; }
        public string? UserId { get; init; }
        public User? User { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
