using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MindBetter.Core.Model.NonProfitAggregate;


namespace MindBetter.Infrastructure.Data.Config
{
    internal class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Service");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(300);

            builder.HasOne(s => s.NonProfit)
                .WithMany(s => s.Services)
                .HasForeignKey(s => s.NonProfitId);

            builder.Property(s => s.Category)
                .HasConversion<int>();
        }
    }
}
