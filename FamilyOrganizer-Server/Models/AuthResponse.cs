namespace FamilyOrganizer_Server.Models;

public class AuthResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = "";
    public string Token { get; set; } = ""; // demo token
    public string? FullName { get; set; }
    public string? Email { get; set; }
}
