using backend.Helpers;
using JetSetGo.Application.Flights.Query.GetById;
using JetSetGo.Application.Flights.Query.Search;
using MediatR;

namespace backend.Endpoints;

public static class FlightEndpoints
{
    public static void MapFlightsEndpoints(this WebApplication application)
    {
        application.MapGet("api/v1/flights",GetAllFlights);
        application.MapPost("api/v1/flights",CreateFlight);
        application.MapGet("api/v1/flights/{id:guid}", GetFlightById);
        application.MapGet("api/v1/flights/search", SearchFlights);
        application.MapGet("/", () => Results.Ok("Hello"));
    }

    private static async Task<IResult> GetAllFlights(ISender sender)
    {
        await Task.CompletedTask;
        return Results.Ok();
    }
    private static async Task<IResult> GetFlightById(ISender sender,Guid id)
    {
        var query = new GetFlightQuery(id);
        var flight = await sender.Send(query);
        return flight.IsFailed ? Results.NotFound(flight.Errors.ToResponse()) : Results.Ok(flight.Value);
    }
    private static async Task<IResult> CreateFlight(ISender sender,Guid id)
    {
        await Task.CompletedTask;
        return Results.Ok();
    }

    private static async Task<IResult> SearchFlights(string locationFrom, string locationTo,
        int passengersNumber, DateOnly date,ISender sender)
    {
        var query = new SearchFlightsQuery(locationFrom, locationTo, passengersNumber, date);
        var flights =await sender.Send(query);
        return flights.Any() ? Results.Ok(flights) : Results.NoContent();
    }
}