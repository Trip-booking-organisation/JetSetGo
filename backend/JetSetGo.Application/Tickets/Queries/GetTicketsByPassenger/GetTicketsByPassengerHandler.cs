using FluentResults;
using JetSetGo.Application.Common.Errors;
using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Domain.Tickets;
using MediatR;

namespace JetSetGo.Application.Tickets.Queries.GetTicketsByPassenger;

public class GetTicketsByPassengerHandler: IRequestHandler<GetTicketsByPassengerQuery,Result<List<Ticket>>>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUserRepository _userRepository;

    public GetTicketsByPassengerHandler(ITicketRepository ticketRepository, IUserRepository userRepository)
    {
        _ticketRepository = ticketRepository;
        _userRepository = userRepository;
    }

    public async Task<Result<List<Ticket>>> Handle(GetTicketsByPassengerQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.Id);
        if (user == null) return Result.Fail(UserErrors.UserNotFound);
        var result = await _ticketRepository.GetTicketsByPassenger(request.Id);
        return result.Any() ? result : Result.Fail<List<Ticket>>(TicketErrors.TicketsNotFound);
    }
}