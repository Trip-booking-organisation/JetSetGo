using FluentResults;
using JetSetGo.Domain.Tickets;
using MediatR;

namespace JetSetGo.Application.Tickets.Queries.GetTicketById;

public record GetTicketByIdQuery(Guid Id) : IRequest<Result<Ticket>>;