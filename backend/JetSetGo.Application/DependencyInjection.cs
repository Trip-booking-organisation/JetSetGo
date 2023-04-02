using JetSetGo.Application.Autentification;
using JetSetGo.Application.Converters;
using Microsoft.Extensions.DependencyInjection;

namespace JetSetGo.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddScoped<DateConverter>();
        return services;
    }
}