﻿namespace Entities.DTOs.UserDto
{
    public record UserForAuthenticationDto
    {
        public string? UserName { get; init; }
        public string? Password { get; init; }
    }
}
