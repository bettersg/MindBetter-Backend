using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MindBetter.Core.Model;

namespace MindBetter.Infrastructure.Data.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.UserName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.FirstName)
                .HasMaxLength(50);


            builder.Property(u => u.LastName)
                .HasMaxLength(50);
        }
    }
}
