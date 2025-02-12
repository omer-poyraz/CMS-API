using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Repositories.EFCore.Config
{
    public class FormElementConfig : IEntityTypeConfiguration<FormElement>
    {
        public void Configure(EntityTypeBuilder<FormElement> builder)
        {
            builder.HasKey(s => s.ID);

            builder
                .Property(b => b.files)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<ICollection<string>>(v)
                );
        }
    }
}
