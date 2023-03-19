using JetSetGo.Domain.Flights.Entities;
using JetSetGo.Domain.Flights.ValueObjects;

namespace JetSetGo.Domain.Flights;

public class Flight
{
    public Guid Id { get; set; }
    public List<Seat> Seats { get; set; } = null!;
    public FlightDetails Departure { get; set; } = null!;
    public FlightDetails Arrival { get; set; } = null!;
}