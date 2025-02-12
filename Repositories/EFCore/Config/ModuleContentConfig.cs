using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Repositories.EFCore.Config
{
    public class ModuleContentConfig : IEntityTypeConfiguration<ModuleContent>
    {
        public void Configure(EntityTypeBuilder<ModuleContent> builder)
        {
            builder.HasKey(s => s.ID);

            builder
                .Property(b => b.Files)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<ICollection<string>>(v)
                );

            builder
                .Property(b => b.Text)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v)
                );

            builder
                .Property(b => b.Slug)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v)
                );
        }
    }
}
