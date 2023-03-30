using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Domain.Flights;
using MediatR;

namespace JetSetGo.Application.Flights.Query.Search;

public class SearchFlightsQueryHandler:IRequestHandler<SearchFlightsQuery,List<Flight>>
{
    private readonly IFlightRepository _flightRepository;

    public SearchFlightsQueryHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<List<Flight>> Handle(SearchFlightsQuery request, CancellationToken cancellationToken)
    {
        var flights = await  _flightRepository.SearchFlights(request);
        // var searchResult = flights.Where(f => 
        //    f.Seats.Count(s => s.Available) >= request.PassengersNumber
        //    && (f.Departure.Address.City.Contains(request.LocationFrom) 
        //        || f.Departure.Address.Country.Contains(request.LocationFrom))
        //    && (f.Arrival.Address.City.Contains(request.LocationTo) 
        //        || f.Arrival.Address.Country.Contains(request.LocationTo))
        //    ).ToList();
       return flights;
    }
}