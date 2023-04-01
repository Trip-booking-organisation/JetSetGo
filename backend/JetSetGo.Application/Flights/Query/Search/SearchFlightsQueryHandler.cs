using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Application.Common.Model;
using JetSetGo.Domain.Flights;
using MediatR;
using Microsoft.Extensions.Logging;

namespace JetSetGo.Application.Flights.Query.Search;

public class SearchFlightsQueryHandler:IRequestHandler<SearchFlightsQuery,IEnumerable<FlightResult>>
{
    private readonly IFlightRepository _flightRepository;
    private readonly ILogger<SearchFlightsQueryHandler> _logger;

    public SearchFlightsQueryHandler(IFlightRepository flightRepository, ILogger<SearchFlightsQueryHandler> logger)
    {
        _flightRepository = flightRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<FlightResult>> Handle(SearchFlightsQuery request, CancellationToken cancellationToken)
    {
        var flights = await  _flightRepository.SearchFlights(request,cancellationToken);
        _logger.LogInformation(request.ToString());
        var result = flights.Select(flight =>
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