using FluentResults;
using JetSetGo.Application.Common.Errors;
using JetSetGo.Application.Common.Interfaces.Tickets;
using JetSetGo.Domain.Tickets;
using MediatR;

namespace JetSetGo.Application.Tickets.Queries.GetTicketsByPassenger;

public class GetTicketsByIdHandler: IRequestHandler<GetTicketsByPassengerQuery,Result<IEnumerable<Ticket>>>
{
    private readonly ITicketRepository _ticketRepository;

    public GetTicketsByIdHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<Result<IEnumerable<Ticket>>> Handle(GetTicketsByPassengerQuery request, CancellationToken cancellationToken)
    {
        var result = await _ticketRepository.GetTicketsByPassenger(request.Id);
        return result == null ? Result.Fail(TicketErrors.TicketsNotFound) : Result.Ok(result);
    }
}