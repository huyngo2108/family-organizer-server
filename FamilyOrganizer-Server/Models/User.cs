using System.Diagnostics;

namespace FamilyOrganizer_Server.Models;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class User
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = ""; // demo: plain text (chỉ để test)
    public string FullName { get; set; } = "";

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
