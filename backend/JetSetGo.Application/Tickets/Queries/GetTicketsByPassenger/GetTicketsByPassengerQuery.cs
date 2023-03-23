using FluentResults;
using JetSetGo.Domain.Tickets;
using MediatR;

namespace JetSetGo.Application.Tickets.Queries.GetTicketsByPassenger;

public record GetTicketsByPassengerQuery(Guid Id) : IRequest<Result<List<Ticket>>>;