using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MindBetter.Core.Model.NPMHOAggregate;


namespace MindBetter.Infrastructure.Data.Config
{
    internal class ServiceCategoryConfig : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.ToTable("ServiceCategories");

            builder.Property(e => e.EnumVal)
                .HasConversion<int>();

            builder.HasKey(e => e.EnumVal);
        }
    }
}
