/*using FluentResults;
using JetSetGo.Application.Common.Errors;
using JetSetGo.Application.Common.Interfaces.Persistence;
using MediatR;

namespace JetSetGo.Application.Tickets.Commands.UpdateTicket;

public class UpdateTicketHandler : IRequestHandler<UpdateTicketCommand, Result>
{
    private readonly ITicketRepository _ticketRepository;

    public UpdateTicketHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<Result> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketRepository.GetTicketById(request.Id);
        if (ticket == null) return Result.Fail(TicketErrors.TicketNotFound);
        
    }
}*/