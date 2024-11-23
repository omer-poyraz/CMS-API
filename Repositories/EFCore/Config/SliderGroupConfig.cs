using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class SliderGroupConfig : IEntityTypeConfiguration<SliderGroup>
    {
        public void Configure(EntityTypeBuilder<SliderGroup> builder)
        {
            builder.HasKey(s=>s.SliderGroupID);
        }
    }
}
