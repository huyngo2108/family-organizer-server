using FamilyOrganizer.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyOrganizer.Server.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        await db.Database.MigrateAsync();

        if (!await db.Users.AnyAsync())
        {
            db.Users.AddRange(
                new User
                {
                    Email = "alice@example.com",
                    Username = "alice",
                    FullName = "Alice",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("pass1234")
                },
                new User
                {
                    Email = "bob@example.com",
                    Username = "bob",
                    FullName = "Bob",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("pass1234")
                }
            );
            await db.SaveChangesAsync();
        }
    }
}
