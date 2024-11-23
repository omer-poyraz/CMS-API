using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class CustomIdentity
    {
        public IdentityResult? IdentityResult { get; set; }
        public string? UserId { get; set; }
    }
}
