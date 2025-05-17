namespace SecureFinanceTracker.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string username);
}
