using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsCleanArch.Domain.Entities;

namespace ProductsCleanArch.Persistence.Configurations
{
    public class UserConfigurstion : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.UserId).HasColumnName("UserID");
            builder.Property(e => e.FullName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.UserName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Occupation).IsRequired().HasMaxLength(40);
            builder.Property(e => e.Age).IsRequired().HasColumnType("int");
        }
    }
}