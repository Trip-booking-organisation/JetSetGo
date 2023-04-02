using JetSetGo.Application.Common.Model;
using JetSetGo.Domain.Flights;

namespace JetSetGo.Application.Flights.Mapper;

public class FlightMapper
{
    public static FlightResult MapFlightToResult(Flight flight)
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
            ArrivalDate = flight.Arrival.Date,
            CompanyName = flight.CompanyName
        };
    }
}