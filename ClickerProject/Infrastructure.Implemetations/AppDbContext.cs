using ClickerProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace ClickerProject.Infrastructure.Implemetations
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.UserBoosts)
                .WithOne(ub => ub.User)
                .HasForeignKey(ub => ub.UserId);

            modelBuilder.Entity<Boost>()
                .HasMany(b => b.UserBoosts)
                .WithOne(b => b.Boost)
                .HasForeignKey(ub => ub.BoostId);

            modelBuilder.Entity<UserBoost>()
                .HasKey(ub => new { ub.UserId, ub.BoostId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
