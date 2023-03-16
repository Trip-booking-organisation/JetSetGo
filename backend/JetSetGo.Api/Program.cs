using System.Configuration;
using backend;
using backend.Endpoints;
using JetSetGo.Application;
using JetSetGo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation(builder.Configuration)
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    app.MapControllers();
    //app.UseExceptionHandler("/error");
    app.MapFlightsEndpoints();
    app.MapAuthenticationEndpoints();
    app.UseCors(
        app.Configuration
            .GetSection("Cors")
            .GetSection("PolicyName").Value!);
    app.Run();
}

