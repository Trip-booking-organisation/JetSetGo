using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Application.Common.Model;
using JetSetGo.Application.Flights.Mapper;
using JetSetGo.Domain.Flights;
using MediatR;
using Microsoft.Extensions.Logging;

namespace JetSetGo.Application.Flights.Query.Search;

public class SearchFlightsQueryHandler:IRequestHandler<SearchFlightsQuery,IEnumerable<FlightResult>>
{
    private readonly IFlightRepository _flightRepository;
    private readonly ILogger<SearchFlightsQueryHandler> _logger;

    public SearchFlightsQueryHandler(IFlightRepository flightRepository, 
        ILogger<SearchFlightsQueryHandler> logger, FlightMapper mapper)
    {
        _flightRepository = flightRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<FlightResult>> Handle(SearchFlightsQuery request, CancellationToken cancellationToken)
    {
        var flights = await  _flightRepository.SearchFlights(request,cancellationToken);
        _logger.LogInformation(request.ToString());
        var result = flights.Select(FlightMapper.MapFlightToResult);
       return result;
    }
}