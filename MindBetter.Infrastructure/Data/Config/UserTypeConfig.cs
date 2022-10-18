using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MindBetter.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBetter.Infrastructure.Data.Config
{
    // TODO : Make this a generic call for all classes that inherit from EnumBaseEntity class
    public class UserTypeConfig : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.ToTable("UserTypes");

            builder.Property(e => e.EnumVal)
                .HasConversion<int>()
                .IsRequired();

            builder.HasKey(e => e.EnumVal);
        }
    }
}
