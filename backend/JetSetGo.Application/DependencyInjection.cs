using JetSetGo.Application.Autentification;
using JetSetGo.Application.Converters;
using JetSetGo.Application.Flights.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace JetSetGo.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddScoped<FlightMapper>();
        return services;
    }
}