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
                },
                new Services
                {
                    ID = 4,
                    Name = "Blog",
                    EndPoint = "/Blog",
                },
                new Services
                {
                    ID = 5,
                    Name = "Form",
                    EndPoint = "/Form",
                },
                new Services
                {
                    ID = 6,
                    Name = "FormElement",
                    EndPoint = "/FormElement",
                },
                new Services
                {
                    ID = 7,
                    Name = "FormResponse",
                    EndPoint = "/FormResponse",
                },
                new Services
                {
                    ID = 8,
                    Name = "LibraryModel",
                    EndPoint = "/LibraryModel",
                },
                new Services
                {
                    ID = 9,
                    Name = "Language",
                    EndPoint = "/Language",
                }
            );
        }
    }
}
