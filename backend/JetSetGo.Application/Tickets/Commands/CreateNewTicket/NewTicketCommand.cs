using FluentResults;
using JetSetGo.Domain.Tickets;
using MediatR;

namespace JetSetGo.Application.Tickets.Commands.CreateNewTicket;

public record NewTicketCommand(Guid FlightId,
    Guid PassengerId,
    string ContactDetails,
    string SeatNumber) : IRequest<Result<Ticket>>;