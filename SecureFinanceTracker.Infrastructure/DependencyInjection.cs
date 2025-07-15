using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecureFinanceTracker.Domain.Interfaces;
using SecureFinanceTracker.Infrastructure.Persistence;
using SecureFinanceTracker.Infrastructure.Repositories;
using SecureFinanceTracker.Application.Common.Interfaces;

namespace SecureFinanceTracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Database connection (can be from appsettings.json or environment)
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Repository DI
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IBudgetRepository, BudgetRepository>();


        return services;
    }
}
