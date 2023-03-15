using JetSetGo.Application;
using JetSetGo.Application.Autentification;
using JetSetGo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddAplication()
        .AddInfrastructure();
    builder.Services.AddDbContext<JetSetGoContext>();

    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.MapControllers();
    app.Run();
}

