using System.Configuration;
using DotNetEnv.Configuration;
using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Application.Persistence;
using JetSetGo.Infrastructure.Persistence;
using JetSetGo.Infrastructure.Persistence.Containers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace JetSetGo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        builderConfiguration.AddDotNetEnv();
        services.AddPersistence();
        return services;
    }
    private static void AddPersistence(this IServiceCollection services){
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IFlightRepository, FlightContainer>();
        services.AddCosmos();
    }
    private static void AddCosmos(this IServiceCollection services){
        services.AddDbContext<JetSetGoContext>();
    }
    
}