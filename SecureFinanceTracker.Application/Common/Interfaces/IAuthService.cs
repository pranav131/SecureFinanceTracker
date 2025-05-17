using SecureFinanceTracker.Application.Auth.Models;

namespace SecureFinanceTracker.Application.Common.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(RegisterRequest request);
    Task<AuthResponse> LoginAsync(LoginRequest request);
}
