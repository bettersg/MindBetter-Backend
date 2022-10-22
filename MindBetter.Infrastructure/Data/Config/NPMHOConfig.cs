using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MindBetter.Core.Model.NPMHOAggregate;

namespace MindBetter.Infrastructure.Data.Config
{
    internal class NPMHOConfig : IEntityTypeConfiguration<NPMHO>
    {
        public void Configure(EntityTypeBuilder<NPMHO> builder)
        {
            builder.ToTable("NPMHO");

            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x => x.Website)
                .IsRequired();

            builder.HasMany(x => x.Services)
                .WithOne(x => x.NPMHO)
                .IsRequired();

            builder.HasMany(x => x.Members)
                .WithOne(x => x.Organisation)
                .IsRequired();
        }
    }
}
