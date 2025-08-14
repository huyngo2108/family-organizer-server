using FamilyOrganizer.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyOrganizer.Server.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var user = modelBuilder.Entity<User>();
            user.Property(x => x.Email).HasMaxLength(255).IsRequired();
            user.Property(x => x.Username).HasMaxLength(32).IsRequired();
            user.Property(x => x.PasswordHash).IsRequired();
            user.Property(x => x.FullName).HasMaxLength(255);
            user.HasIndex(x => x.Email).IsUnique();
            user.HasIndex(x => x.Username).IsUnique();
        }
    }
}
