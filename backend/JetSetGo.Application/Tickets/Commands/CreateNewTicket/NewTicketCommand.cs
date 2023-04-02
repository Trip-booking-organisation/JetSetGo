using FluentResults;
using JetSetGo.Domain.Tickets;
using MediatR;

namespace JetSetGo.Application.Tickets.Commands.CreateNewTicket;

public record NewTicketCommand(
    string ContactDetails,
    string SeatNumber);

public    record NewTicketsCommand(Guid FlightId,
    List<NewTicketCommand> NewTickets,
    Guid PassengerId) : IRequest<Result<bool>>;