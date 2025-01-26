using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Repositories.EFCore.Config
{
    public class ServicesConfig : IEntityTypeConfiguration<Services>
    {
        public void Configure(EntityTypeBuilder<Services> builder)
        {
            builder.HasKey(s => s.ID);

            builder.HasData(
                new Services
                {
                    ID = 1,
                    Name = "UserPermission",
                    EndPoint = "/UserPermission",
                },
                new Services
                {
                    ID = 2,
                    Name = "User",
                    EndPoint = "/User",
                },
                new Services
                {
                    ID = 3,
                    Name = "Services",
                    EndPoint = "/Services",
                }
            );
        }
    }
}
