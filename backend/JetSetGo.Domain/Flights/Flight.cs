using FluentResults;
using JetSetGo.Domain.DomainExceptions;
using JetSetGo.Domain.Flights.Entities;
using JetSetGo.Domain.Flights.ValueObjects;

namespace JetSetGo.Domain.Flights;

public class Flight
{
    public Flight(List<Seat> seats, FlightDetails departure, FlightDetails arrival)
    {
        Seats = seats;
        Departure = departure;
        Arrival = arrival;
        Seats = seats;
        AvailableSeats = InitAvailableSeats();
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public List<Seat> Seats { get;private  set; }
    public FlightDetails Departure { get; private set; }
    public FlightDetails Arrival { get; private set; }
    public int AvailableSeats { get; set; }

    public Result Validate()
    {
        return Result.Merge(ValidateSets(),ValidateArrivalAndDeparture());
    }
    private Result ValidateSets()
    {
        var isAnyWithSameName = Seats.GroupBy(s => s.SeatNumber)
                                .Any(s => s.Count() > 1);
        return isAnyWithSameName ? Result.Fail(DomainException.Flight.SeatError) : Result.Ok();
    }

    private Result ValidateArrivalAndDeparture()
    {
        return Arrival.IsAfterDate(Departure) ? Result.Fail(DomainException.Flight.DateError) : Result.Ok();
    }

    private int InitAvailableSeats()
    {
        return Seats.Count(x => x.Available);
    }

    public Result AddSeat(Seat seat)
    {
        if (Seats.Any(s => s.SeatNumber.Equals(seat.SeatNumber)))
        {
            return Result.Fail(DomainException.Flight.SeatError);
        }
        Seats.Add(seat);
        return Result.Ok();
    }

#pragma warning disable CS8618
    private Flight()
#pragma warning restore CS8618
    {
    }
}