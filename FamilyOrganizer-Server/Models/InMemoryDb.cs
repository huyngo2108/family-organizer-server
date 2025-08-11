using System.Collections.Generic;

namespace FamilyOrganizer_Server.Models;

public static class InMemoryDb
{
    public static List<User> Users = new()
    {
        new User { Email = "demo@example.com", Password = "P@ssw0rd", FullName = "Demo User" },
        new User { Email = "huy@example.com",  Password = "123456",   FullName = "Huy Ngo" }
    };
}
