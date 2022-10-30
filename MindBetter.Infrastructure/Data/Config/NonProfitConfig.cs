using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MindBetter.Core.Model.NonProfitAggregate;

namespace MindBetter.Infrastructure.Data.Config
{
    internal class NonProfitConfig : IEntityTypeConfiguration<NonProfit>
    {
        public void Configure(EntityTypeBuilder<NonProfit> builder)
        {
            builder.ToTable("NonProfit");

            builder.HasKey(n => n.Id);

            builder.Property(n => n.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(n => n.WebsiteURL)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
