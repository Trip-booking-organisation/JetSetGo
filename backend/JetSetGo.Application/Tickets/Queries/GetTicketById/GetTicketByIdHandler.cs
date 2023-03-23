using FluentResults;
using JetSetGo.Application.Common.Errors;
using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Domain.Tickets;
using MediatR;

namespace JetSetGo.Application.Tickets.Queries.GetTicketById;

public class GetTicketByIdHandler : IRequestHandler<GetTicketByIdQuery,Result<Ticket>>
{
    private readonly ITicketRepository _ticketRepository;

    public GetTicketByIdHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<Result<Ticket>> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketRepository.GetTicketById(request.Id);
        return ticket ?? Result.Fail<Ticket>(TicketErrors.TicketNotFound);
    }
}