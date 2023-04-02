using FluentResults;

namespace JetSetGo.Application.Common.Errors;

public static class TicketErrors
{
    public static IError TicketsNotFound=> new Error("Tickets not found!");
    public static IError TicketNotFound=> new Error("Ticket not found!");
    public static IError TicketNotCreated=> new Error("Ticket is not created!");

}