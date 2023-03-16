using System.Configuration;
using JetSetGo.Application;
using JetSetGo.Infrastructure;
using JetSetGoBackend;
using JetSetGoBackend.Endpoints;

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
    app.UseCors(
        app.Configuration
        .GetSection("Cors")
        .GetSection("PolicyName").Value!);
    app.Run();
}
