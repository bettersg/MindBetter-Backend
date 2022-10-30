using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MindBetter.Core.Model.NonProfitAggregate;

namespace MindBetter.Infrastructure.Data.Config
{
    public class PermissionTypeLookupConfig : IEntityTypeConfiguration<PermissionTypeLookup>
    {
        public void Configure(EntityTypeBuilder<PermissionTypeLookup> builder)
        {
            builder.ToTable("PermissionTypesLookup");

            builder.Property(e => e.EnumVal)
                .HasConversion<int>()
                .IsRequired();

            builder.HasKey(e => e.EnumVal);

            builder.HasData(Seed.GetEnumLookupTable<PermissionTypeLookup, PermissionTypeEnum>());
        }
    }
}
