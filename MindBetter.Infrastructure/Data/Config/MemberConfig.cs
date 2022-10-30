using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MindBetter.Core.Model.NonProfitAggregate;


namespace MindBetter.Infrastructure.Data.Config
{
    internal class MemberConfig : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("NonProfitMember");

            builder.Property(m => m.Designation)
                .IsRequired();

            builder.HasOne(m => m.NonProfit)
               .WithMany(n => n.Members)
               .HasForeignKey(m => m.NonProfitId);

            builder.Property(m => m.PermissionType)
                .HasConversion<int>();
        }
    }
}
