using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence;

public class RoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.HasData(
            new AppRole
            {
                Id = "9793B088-B22B-41E1-BF29-CD15E23568ED",
                Name = "Admin",
                NormalizedName = "ADMIN",
                Description = "Hotel Administrator"
            },
            new AppRole
            {
                Id = "58F9F2DB-FB85-4655-A801-BAC792EFF977",
                Name = "Traveller",
                NormalizedName = "TRAVELLER",
                Description = "Travellers"
            }
        );
    }
}
