using FluentResults;
using JetSetGo.Application.Common.Errors;
using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Domain.Tickets;
using MediatR;

namespace JetSetGo.Application.Tickets.Commands.DeleteTicket;

public class DeleteTicketHandler : IRequestHandler<DeleteTicketCommand,Result>
{
    private readonly ITicketRepository _ticketRepository;

    public DeleteTicketHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<Result> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketRepository.GetTicketById(request.Id);
        if (ticket == null) return Result.Fail(TicketErrors.TicketNotFound);
        await _ticketRepository.DeleteTicket(ticket);
        return Result.Ok();
    }
}