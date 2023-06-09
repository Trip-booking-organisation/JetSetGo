﻿using AutoMapper;
using backend.Dto.Requests.Tickets;
using backend.Helpers;
using JetSetGo.Application.Tickets.Commands.CreateNewTicket;
using JetSetGo.Application.Tickets.Commands.DeleteTicket;
using JetSetGo.Application.Tickets.Queries.GetTicketById;
using JetSetGo.Application.Tickets.Queries.GetTicketsByPassenger;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace backend.Endpoints;

public static class TicketEndpoint
{
    public static void MapTicketsEndpoints(this WebApplication application)
    {
        application.MapGet("api/v1/tickets/{id:guid}",GetAllTicketsByPassenger).RequireAuthorization();
        application.MapPost("api/v1/tickets",CreateTicket).RequireAuthorization("PassengerPolicy");
        application.MapGet("api/v1/tickets/get-ticket/{id:guid}", GetTicketById).RequireAuthorization();
      //  application.MapPut("api/v1/tickets", UpdateTicket);
        application.MapDelete("api/v1/tickets/{id:guid}", DeleteTicket).RequireAuthorization();
    }
    private static async Task<IResult> GetAllTicketsByPassenger(ISender sender,Guid id)
    {
        var request = new GetTicketsByPassengerQuery(id);
        var result = await sender.Send(request);
        return result.IsFailed ? Results.NotFound(result.Errors.ToResponse()) : Results.Ok(result.Value);
    }

    private static async Task<IResult> GetTicketById(ISender sender, Guid id)
    {
        var request = new GetTicketByIdQuery(id);
        var result = await sender.Send(request);
        return result.IsFailed ? Results.NotFound(result.Errors.ToResponse()) : Results.Ok(result.Value);
    }

    private static async Task<IResult> CreateTicket(IMapper mapper,ISender sender,[FromBody] NewTicketsRequest request)
    {
        var ticket = mapper.Map<NewTicketsCommand>(request);
        var result = await sender.Send(ticket);
        return Results.Created(nameof(GetTicketById),result);
    }
    private static async Task<IResult> DeleteTicket(ISender sender, Guid id)
    {
        var ticket = new DeleteTicketCommand(id);
        var result = await sender.Send(ticket);
        return result.IsFailed ? Results.NotFound(result.Errors.ToResponse()) : Results.NoContent();
    }

    /*private static Task UpdateTicket(HttpContext context)
    {
        throw new NotImplementedException();
    }*/
}