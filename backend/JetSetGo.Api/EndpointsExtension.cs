using backend.Endpoints;

namespace backend;

public static class EndpointsExtension
{
    public static void MapEndpoints(this WebApplication webApplication)
    {
        webApplication.MapFlightsEndpoints();
        webApplication.MapAuthenticationEndpoints();
    }
}