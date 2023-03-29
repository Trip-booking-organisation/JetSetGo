using System.Text;
using DotNetEnv.Configuration;
using JetSetGo.Application.Common.Interfaces.Autentification;
using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Application.Common.Services;
using JetSetGo.Infrastructure.Autentification;
using JetSetGo.Infrastructure.Persistence;
using JetSetGo.Infrastructure.Persistence.Containers;
using JetSetGo.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace JetSetGo.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        builderConfiguration.AddDotNetEnv();
        services.AddAuth(builderConfiguration);

        services.AddPersistence();
        services.AddServices();
    }
    private static void AddPersistence(this IServiceCollection services){
        services.AddDbContext<JetSetGoContext>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IFlightRepository, FlightRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
    }

    private static void AddServices(this IServiceCollection services){
        services.AddSingleton<IDateTimeProvider,DateTimeProvider>();
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager builderConfiguration)
    {
        var jwtSettings = new JwtSettings();
        builderConfiguration.Bind(JwtSettings.SectionName,jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options=>options.TokenValidationParameters= new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret))
                
            });
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Authorized", policy =>
            {
                policy.RequireAuthenticatedUser();
            });
        });
        
        return services;
    }
    
}