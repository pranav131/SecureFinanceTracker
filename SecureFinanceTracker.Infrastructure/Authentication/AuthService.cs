using SecureFinanceTracker.Application.Auth.Models;
using SecureFinanceTracker.Application.Common.Interfaces;
using SecureFinanceTracker.Domain.Entities;
using SecureFinanceTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SecureFinanceTracker.Infrastructure.Authentication;

public class AuthService : IAuthService
{
    private readonly AppDbContext _dbContext;
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AuthService(AppDbContext dbContext, IJwtTokenGenerator tokenGenerator)
    {
        _dbContext = dbContext;
        _tokenGenerator = tokenGenerator;
        _passwordHasher = new PasswordHasher<User>();
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        if (await _dbContext.Users.AnyAsync(u => u.Username == request.Username))
            throw new Exception("Username already exists");

        var user = new User
        {
            Username = request.Username,
        };
        user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        var token = _tokenGenerator.GenerateToken(user.Id, user.Username);

        return new AuthResponse { UserId = user.Id, Username = user.Username, Token = token };
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == request.Username)
            ?? throw new Exception("Invalid username or password");

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
        if (result == PasswordVerificationResult.Failed)
            throw new Exception("Invalid username or password");

        var token = _tokenGenerator.GenerateToken(user.Id, user.Username);

        return new AuthResponse { UserId = user.Id, Username = user.Username, Token = token };
    }
}
