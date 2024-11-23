using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repositories.EFCore
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Header> Headers { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderGroup> SliderGroups { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Seo> Seos { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentGroup> DocumentGroups { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageGroup> ImageGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
