using JetSetGo.Application.Autentification;
using Microsoft.Extensions.DependencyInjection;

namespace JetSetGo.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddScoped<IAutentificationCommandService, AutentificationCommandService>();
        return services;
    }
}