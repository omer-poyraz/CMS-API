using Entities.Models;

namespace Repositories.EFCore.Extensions
{
    public static class SearchExtensions
    {
        public static IQueryable<User> SearchUser(this IQueryable<User> user, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return user;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return user.Where(u => u.UserName!.ToLower().Contains(lowerCaseTerm));
        }
    }
}
