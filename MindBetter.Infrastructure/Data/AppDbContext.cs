using Microsoft.EntityFrameworkCore;
using MindBetter.Core.Entities;
using MindBetter.Core.Entities.NPMHOAggregate;
using MindBetter.Infrastructure.Data.Config;
using System.Reflection;

namespace MindBetter.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //public DbSet<EnumBaseEntity> EnumBaseEntities { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TODO - remove abstract class table creation
            // create tables for abstract classes (EF Core 7 should remove this requirement)
            modelBuilder.Entity<BaseEntity>().ToTable("BaseEntities");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
