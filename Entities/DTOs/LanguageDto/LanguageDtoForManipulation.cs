using System.Text.Json;
using Entities.Models;

namespace Entities.DTOs.LanguageDto
{
    public abstract record LanguageDtoForManipulation
    {
        public string? File { get; set; }
        public string? Title { get; init; }
        public string? UserId { get; init; }
    }
}
