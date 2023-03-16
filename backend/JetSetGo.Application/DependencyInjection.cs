﻿using JetSetGo.Application.Autentification;
using Microsoft.Extensions.DependencyInjection;

namespace JetSetGo.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        return services;
    }
}