using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MindBetter.Core.Model.NonProfitAggregate;


namespace MindBetter.Infrastructure.Data.Config
{
    internal class ServiceCategoryLookupConfig : IEntityTypeConfiguration<ServiceCategoryLookup>
    {
        public void Configure(EntityTypeBuilder<ServiceCategoryLookup> builder)
        {
            builder.ToTable("ServiceCategoryLookup");

            builder.Property(e => e.EnumVal)
                .HasConversion<int>()
                .IsRequired();

            builder.HasKey(e => e.EnumVal);

            builder.HasData(Seed.GetEnumLookupTable<ServiceCategoryLookup, ServiceCategoryEnum>());
        }
    }
}
