using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class User : IdentityUser
    {
        public string? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? RefreshToken { get; set; }
        public string? Gender { get; set; }
        public string? Company { get; set; }
        public string? Phone2 { get; set; }
        public string? Fax { get; set; }
        public string? Address { get; set; }
        public DateTime RefreshTokenExpireTime { get; set; }
        public ICollection<IdentityRole>? Roles { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public User()
        {
            UserId = Id;
        }
    }
}
