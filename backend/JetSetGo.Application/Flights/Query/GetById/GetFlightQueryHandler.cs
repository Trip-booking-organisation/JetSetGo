using FluentResults;
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
        var env =Environment.GetEnvironmentVariable("DB_ACC_ENDPOINT");
        _logger.LogInformation("About page visited at {DT}", 
            DateTime.UtcNow.ToLongTimeString());
        _logger.LogInformation("Key {env}", 
            env);
        var flight = await _flightRepository.GetById(request.Id);
        return flight ?? Result.Fail<Flight>("Cannot find flight");
    }
}