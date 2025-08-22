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

            user.ToTable("users");

            user.HasKey(x => x.Id);

            user.Property(x => x.Email)
                .HasMaxLength(255)
                .IsRequired()
                .HasColumnName("email");

            user.Property(x => x.Username)
                .HasMaxLength(32)
                .IsRequired()
                .HasColumnName("username");

            user.Property(x => x.PasswordHash)
                .IsRequired()
                .HasColumnName("password_hash");

            user.Property(x => x.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");

            user.HasIndex(x => x.Email).IsUnique();
            user.HasIndex(x => x.Username).IsUnique();
        }
    }
}
