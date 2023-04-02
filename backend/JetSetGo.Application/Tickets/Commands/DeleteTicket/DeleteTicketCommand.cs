using FluentResults;
using MediatR;

namespace JetSetGo.Application.Tickets.Commands.DeleteTicket;

public record DeleteTicketCommand(Guid Id) : IRequest<Result>;
