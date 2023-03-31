using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Application.Common.Model;
using JetSetGo.Domain.Flights;
using MediatR;

namespace JetSetGo.Application.Flights.Query.Search;

public class SearchFlightsQueryHandler:IRequestHandler<SearchFlightsQuery,IEnumerable<FlightResult>>
{
    private readonly IFlightRepository _flightRepository;

    public SearchFlightsQueryHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<IEnumerable<FlightResult>> Handle(SearchFlightsQuery request, CancellationToken cancellationToken)
    {
        var flights = await  _flightRepository.SearchFlights(request,cancellationToken);
        var searchResult = flights.Where(f => 
           (f.Departure.Address.City.Contains(request.LocationFrom) 
               || f.Departure.Address.Country.Contains(request.LocationFrom))
           && (f.Arrival.Address.City.Contains(request.LocationTo) 
               || f.Arrival.Address.Country.Contains(request.LocationTo))
           ).ToList();
        var result = searchResult.Select(flight =>
        {
            var totalPrize = flight.Seats.Sum(s => s.Price);
            return new FlightResult
            {
                Id = flight.Id,
                TotalTicketPrize = totalPrize,
                Seats = flight.Seats.Select(seat =>
                    new SeatResult
                    {
                        SeatNumber = seat.SeatNumber,
                        Price = seat.Price,
                        Available = seat.Available,
                        Class = seat.Class.ToString()
                    }),
                DepartureAddress = flight.Departure.Address,
                ArrivalAddress = flight.Arrival.Address,
                ArrivalTime = flight.Arrival.Time,
                DepartureTime = flight.Departure.Time,
                DepartureDate = flight.Departure.Date,
                ArrivalDate = flight.Arrival.Date
            };
        });
       return result;
    }
}