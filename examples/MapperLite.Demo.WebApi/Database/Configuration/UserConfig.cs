using MapperLite.Demo.Helpers;
using MapperLite.Demo.Models.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MapperLite.Demo.WebApi.Database.Configuration;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        builder.Property(x => x.FirstName)
            .HasMaxLength(128)
            .IsRequired();
        builder.Property(x => x.LastName)
            .HasMaxLength(128)
            .IsRequired();

        builder.HasData(UserGenerator.GenerateUsers(20, false));
    }
}
