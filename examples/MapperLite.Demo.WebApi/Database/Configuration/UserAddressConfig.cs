using MapperLite.Demo.Helpers;
using MapperLite.Demo.Models.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MapperLite.Demo.WebApi.Database.Configuration;

public class UserAddressConfig : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        builder.Property(x => x.Street)
            .HasMaxLength(256)
            .IsRequired();
        builder.Property(x => x.Number)
            .HasMaxLength(32)
            .IsRequired(false);
        builder.Property(x => x.City)
            .HasMaxLength(128)
            .IsRequired();
        builder.Property(x => x.ZipCode)
            .HasMaxLength(16)
            .IsRequired();
        builder.Property(x => x.UserId)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.Addresses)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(UserAddressGenerator.GenerateUserAddresses(40, 20));
    }
}
