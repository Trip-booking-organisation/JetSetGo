using JetSetGo.Application.Flights.Query.GetById;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JetSetGoBackend.Endpoints;

public static class FlightEndpoints
{
    public static void MapFlightsEndpoints(this WebApplication application)
    {
        application.MapGet("flights",GetAllFlights);
        application.MapPost("flights",CreateFlight);
        application.MapGet("flights/{id:guid}", GetFlightById);
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
        return flight.IsFailed ? Results.NotFound() : Results.Ok(flight.Value);
    }
    private static async Task<IResult> CreateFlight(ISender sender,Guid id)
    {
        await Task.CompletedTask;
        return Results.Ok();
    }
}