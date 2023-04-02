using FluentResults;
using JetSetGo.Application.Common.Errors;
using JetSetGo.Application.Common.Interfaces.Persistence;
using MediatR;

namespace JetSetGo.Application.Flights.Command.DeleteFlight;

public class DeleteFlightHandler : IRequestHandler<DeleteFlightCommand,Result>
{
    private readonly IFlightRepository _flightRepository;
    private readonly ITicketRepository _ticketRepository;

    public DeleteFlightHandler(IFlightRepository flightRepository, ITicketRepository ticketRepository)
    {
        _flightRepository = flightRepository;
        _ticketRepository = ticketRepository;
    }

    public async Task<Result> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
    {
        var flight = await _flightRepository.GetById(request.Id);
        if (flight is null) return Result.Fail(FlightErrors.FlightNotFound);

        var tickets = await _ticketRepository.GetTicketsByFlight(request.Id);
        if (tickets.Any()) return Result.Fail(FlightErrors.FlightHasTickets);
        
        await _flightRepository.Delete(flight);
        return Result.Ok();
    }


}