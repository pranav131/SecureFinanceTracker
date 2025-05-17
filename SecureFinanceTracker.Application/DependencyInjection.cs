using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace SecureFinanceTracker.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register all MediatR handlers in this assembly
        services.AddMediatR(Assembly.GetExecutingAssembly());

        // Register all AutoMapper profiles in this assembly
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // Register all FluentValidation validators in this assembly
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
