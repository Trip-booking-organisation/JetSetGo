using MediatR;

namespace backend.Endpoints;

public static class TicketEndpoint
{
    public static void MapTicketsEndpoints(this WebApplication application)
    {
        application.MapGet("api/v1/tickets",GetAllTickets);
        application.MapPost("api/v1/tickets",CreateTicket);
        application.MapGet("api/v1/tickets/{id:guid}", GetTicketById);
        application.MapPut("api/v1/tickets", UpdateTicket);
        application.MapDelete("api/v1/tickets/{id:guid}", DeleteTicket);
    }
    private static Task GetAllTickets(ISender sender)
    {
        throw new NotImplementedException();
    }

    private static Task GetTicketById(ISender sender)
    {
        throw new NotImplementedException();
    }

 
    private static Task CreateTicket(ISender sender)
    {
        throw new NotImplementedException();
    }
    
    private static Task UpdateTicket(ISender sender)
    {
        throw new NotImplementedException();
    }
    private static Task DeleteTicket(ISender sender)
    {
        throw new NotImplementedException();
    }
}