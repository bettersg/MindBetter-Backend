using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MindBetter.Core.Model.NPMHOAggregate;


namespace MindBetter.Infrastructure.Data.Config
{
    internal class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");

            builder.Property(x => x.Description)
                .IsRequired();

            //builder.Property(x => x.ServiceProvider)
            //    .IsRequired();

            //builder.Property(x => x.Category)
            //    .IsRequired();

            builder.HasOne(s => s.NPMHO)
                .WithMany(s => s.Services)
                .HasForeignKey("NPMHO_Id");

            builder.HasOne(s => s.Category)
                .WithMany()
                .HasForeignKey("ServiceCategory_Id");
        }
    }
}
