using FluentResults;
using MediatR;

namespace JetSetGo.Application.Tickets.Commands.UpdateTicket;

public record UpdateTicketCommand(Guid Id,Guid FlightId,
    Guid PassengerId,
    string ContactDetails,
    string SeatNumber) : IRequest<Result>;
