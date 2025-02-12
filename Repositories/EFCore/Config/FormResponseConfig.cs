using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Repositories.EFCore.Config
{
    public class FormResponseConfig : IEntityTypeConfiguration<FormResponse>
    {
        public void Configure(EntityTypeBuilder<FormResponse> builder)
        {
            builder.HasKey(s => s.ID);

            builder
                .Property(b => b.files)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<ICollection<string>>(v)
                );

            builder
                .Property(p => p.Response)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v)
                );
        }
    }
}
