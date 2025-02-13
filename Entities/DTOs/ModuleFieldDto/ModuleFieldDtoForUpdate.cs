﻿using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.ModuleFieldDto
{
    public record ModuleFieldDtoForUpdate : ModuleFieldDtoForManipulation
    {
        public int ID { get; init; }
        public ICollection<IFormFile>? file { get; set; } = new List<IFormFile>();
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
