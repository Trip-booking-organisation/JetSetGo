using AutoMapper;
using backend.Dto.Requests.Flights;
using backend.Helpers;
using JetSetGo.Application.Flights.Command.CreateFlight;
using JetSetGo.Application.Flights.Command.DeleteFlight;
using JetSetGo.Application.Flights.Query.GetById;
using JetSetGo.Application.Flights.Query.Search;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace backend.Endpoints;

public static class FlightEndpoints
{
    public static void MapFlightsEndpoints(this WebApplication application)
    {
        application.MapGet("api/v1/flights",GetAllFlights);
        application.MapPost("api/v1/flights",CreateFlight);
        application.MapGet("api/v1/flights/{id:guid}", GetFlightById);
        application.MapDelete("api/v1/flights/{id:guid}", DeleteFlight);
        application.MapGet("api/v1/flights/search", SearchFlights);
        application.MapGet("/", () => Results.Ok("Hello"));
    }

    private static async Task<IResult> DeleteFlight(ISender sender,[FromRoute] Guid id)
    {
        var result = await sender.Send(new DeleteFlightCommand(id));
        return result.IsFailed ? Results.Conflict(result.Errors.ToResponse()) : Results.NoContent();
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
        return flight.IsFailed ? Results.Conflict(flight.Errors.ToResponse()) : Results.Ok(flight.Value);
    }
    private static async Task<IResult> CreateFlight(ISender sender,CreateFlight request,IMapper mapper)
    {
        var flight = mapper.Map<CreateFlightCommand>(request);
        var result = await sender.Send(flight);
        return result.IsFailed
            ? Results.BadRequest(result.Errors.ToResponse())
            : Results.Created("/api/v1/flights/{id}", new { Id = result.Value});
    }

    private static async Task<IResult> SearchFlights(string locationFrom, string locationTo,
        int passengersNumber, DateOnly date,ISender sender)
    {
        var query = new SearchFlightsQuery(locationFrom, locationTo, passengersNumber, date);
        var flights = await sender.Send(query);
        return Results.Ok(flights);
    }
}