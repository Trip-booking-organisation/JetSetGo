using FluentResults;
using JetSetGo.Domain.DomainExceptions;
using JetSetGo.Domain.Flights.Entities;
using JetSetGo.Domain.Flights.ValueObjects;

namespace JetSetGo.Domain.Flights;

public class Flight
{
    public Flight(List<Seat> seats, FlightDetails departure, FlightDetails arrival, int availableSeats)
    {
        Seats = seats;
        Departure = departure;
        Arrival = arrival;
        AvailableSeats = availableSeats;
    }

    public static Result ValidateSets(IEnumerable<Seat> seats)
    {
        if (seats.GroupBy(s => s.SeatNumber)
            .Any(s => s.Count() > 1))
        {
            return Result.Fail(DomainException.Flight.SeatError);
        }
        return Result.Ok();
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public List<Seat> Seats { get;private  set; }
    public FlightDetails Departure { get; private set; }
    public FlightDetails Arrival { get; private set; }
    public int AvailableSeats { get; set; }

    public Result AddSeat(Seat seat)
    {
        if (Seats.Any(s => s.SeatNumber.Equals(seat.SeatNumber)))
        {
            return Result.Fail(DomainException.Flight.SeatError);
        }
        Seats.Add(seat);
        return Result.Ok();
    }

    private Flight()
    {
    }
}