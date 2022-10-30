using Microsoft.EntityFrameworkCore;
using MindBetter.Core.Model;
using MindBetter.Core.Model.NonProfitAggregate;
using System.Reflection;

namespace MindBetter.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PermissionTypeLookup> PermissionTypes { get; set; }
        public DbSet<NonProfit> NonProfits { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Member> NonProfitMembers { get; set; }
        public DbSet<ServiceCategoryLookup> ServiceCategories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }

    }
}
