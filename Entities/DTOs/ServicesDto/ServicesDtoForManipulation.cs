using System.Text.Json;
using Entities.Models;

namespace Entities.DTOs.ServicesDto
{
    public abstract record ServicesDtoForManipulation
    {
        public string? Name { get; init; }
        public string? EndPoint { get; init; }
        public string? UserId { get; init; }
    }
}
