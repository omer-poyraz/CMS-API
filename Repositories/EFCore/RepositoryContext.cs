using System.Reflection;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EFCore
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormElement> FormElements { get; set; }
        public DbSet<FormResponse> FormResponses { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LibraryModel> LibraryModels { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Entities.Models.Module> Modules { get; set; }
        public DbSet<ModuleContent> ModuleContents { get; set; }
        public DbSet<ModuleField> ModuleFields { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
