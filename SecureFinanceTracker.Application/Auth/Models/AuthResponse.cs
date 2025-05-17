namespace SecureFinanceTracker.Application.Auth.Models;

public class AuthResponse
{
    public Guid UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}
