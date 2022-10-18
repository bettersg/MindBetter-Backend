using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MindBetter.Core.Model.NPMHOAggregate;


namespace MindBetter.Infrastructure.Data.Config
{
    internal class NPMHOMemberConfig : IEntityTypeConfiguration<NPMHOMember>
    {
        public void Configure(EntityTypeBuilder<NPMHOMember> builder)
        {
            builder.ToTable("NPMHOMember");

            builder.Property(x => x.Designation)
                .IsRequired();

            //builder.Property(x => x.Organisation)
            //    .IsRequired();

            //builder.Property(x => x.Type)
            //    .IsRequired();

            builder.HasOne(s => s.Organisation)
               .WithMany(s => s.Members)
               .HasForeignKey("NPMHO_Id");

            builder.HasOne(s => s.Type)
                .WithMany()
                .HasForeignKey("PermissionType_Id");
        }
    }
}
