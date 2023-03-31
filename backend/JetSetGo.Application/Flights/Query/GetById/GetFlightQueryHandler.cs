using FluentResults;
using JetSetGo.Application.Common.Errors;
using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Domain.Flights;
using MediatR;
using Microsoft.Extensions.Logging;

namespace JetSetGo.Application.Flights.Query.GetById;

public class GetFlightQueryHandler : IRequestHandler<GetFlightQuery,Result<Flight>>
{
    private readonly IFlightRepository _flightRepository;
    private readonly ILogger<GetFlightQueryHandler> _logger;

    public GetFlightQueryHandler(IFlightRepository flightRepository, ILogger<GetFlightQueryHandler> logger)
    {
        _flightRepository = flightRepository;
        _logger = logger;
    }

    public async Task<Result<Flight>> Handle(GetFlightQuery request, CancellationToken cancellationToken)
    {
      
        var flight = await _flightRepository.GetById(request.Id);
        if (flight is not null) return flight;
        _logger.LogError("Flight with {id} is null",request.Id);
        return Result.Fail<Flight>(FlightErrors.FlightNotFound);
    }
}