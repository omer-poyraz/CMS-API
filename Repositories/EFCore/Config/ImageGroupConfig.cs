using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class ImageGroupConfig : IEntityTypeConfiguration<ImageGroup>
    {
        public void Configure(EntityTypeBuilder<ImageGroup> builder)
        {
            builder.HasKey(m => m.ImageGroupID);
        }
    }
}
