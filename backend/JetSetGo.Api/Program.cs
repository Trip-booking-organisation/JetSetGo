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
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    //app.UseExceptionHandler("/error");
    app.MapEndpoints();
    app.UseHttpsRedirection();
    app.UseCors(app.Configuration
            .GetSection("Cors")
            .GetSection("PolicyName").Value!);
    //app.RunCosmosCreation();
    app.Run();
}

