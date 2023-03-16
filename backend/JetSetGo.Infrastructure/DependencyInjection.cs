using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using DotNetEnv.Configuration;
using JetSetGo.Application.Common.Interfaces.Autentification;
using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Application.Common.Services;
using JetSetGo.Application.Persistence;
using JetSetGo.Infrastructure.Autentification;
using JetSetGo.Infrastructure.Persistence;
using JetSetGo.Infrastructure.Persistence.Containers;
using JetSetGo.Infrastructure.Services;
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
        services.AddServices();
        services.AddConfiguration(builderConfiguration);
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
    
    private static void AddServices(this IServiceCollection services){
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider,DateTimeProvider>();
    }

    private static void AddConfiguration(this IServiceCollection services, ConfigurationManager builderConfiguration)
    {
        services.Configure<JwtSettings>(builderConfiguration.GetSection(JwtSettings.SectionName));
    }
    
}