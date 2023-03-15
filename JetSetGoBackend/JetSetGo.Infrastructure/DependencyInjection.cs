using System.Configuration;
using JetSetGo.Application.Persistence;
using JetSetGo.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace JetSetGo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}