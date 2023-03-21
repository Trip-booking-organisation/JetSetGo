using DotNetEnv.Configuration;
using JetSetGo.Application.Common.Interfaces.Autentification;
using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Application.Common.Interfaces.Tickets;
using JetSetGo.Application.Common.Services;
using JetSetGo.Application.Persistence;
using JetSetGo.Infrastructure.Autentification;
using JetSetGo.Infrastructure.Persistence;
using JetSetGo.Infrastructure.Persistence.Containers;
using JetSetGo.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace JetSetGo.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        builderConfiguration.AddDotNetEnv();
        services.AddPersistence();
        services.AddServices();
        services.AddConfiguration(builderConfiguration);
    }
    private static void AddPersistence(this IServiceCollection services){
        services.AddDbContext<JetSetGoContext>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IFlightRepository, FlightRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
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