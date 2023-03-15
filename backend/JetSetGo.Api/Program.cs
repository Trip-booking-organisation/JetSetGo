using JetSetGo.Application;
using JetSetGo.Infrastructure;
using JetSetGoBackend;
using JetSetGoBackend.Endpoints;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
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
    app.Run();
}

