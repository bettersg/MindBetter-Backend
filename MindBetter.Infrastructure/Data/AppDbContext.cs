using Microsoft.EntityFrameworkCore;
using MindBetter.Core.Model;
using MindBetter.Core.Model.NPMHOAggregate;
using MindBetter.Infrastructure.Data.Config;
using System.Reflection;

namespace MindBetter.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<PermissionType> UserTypes { get; set; }

        //public DbSet<NPMHO> NPMHOs { get; set; }
        //public DbSet<Service> Services { get; set; }

        //public DbSet<NPMHOMember> NPMHOMembers { get; set;}

        //public DbSet<ServiceCategory> ServiceCategories { get; set;  }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
