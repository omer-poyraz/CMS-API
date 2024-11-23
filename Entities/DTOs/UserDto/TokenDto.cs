namespace Entities.DTOs.UserDto
{
    public class TokenDto
    {
        public string? UserId { get; init; }
        public string? Name { get; init; }
        public string? AccessToken { get; init; }
        public string? RefreshToken { get; init; }
    }
}
