using JetSetGo.Domain.Flights.ValueObjects;

namespace JetSetGo.Application.Common.Model;

public class FlightResult
{
    public Guid Id { get; set; }
    public double  TotalTicketPrize { get; set; }
    public IEnumerable<SeatResult> Seats { get; set; } = null!;
    public Address DepartureAddress { get; set; } = null!;
    public Address ArrivalAddress { get; set; } = null!;
    public TimeOnly ArrivalTime { get; set; }
    public TimeOnly DepartureTime { get; set; }
    public DateOnly DepartureDate { get; set; }
    public DateOnly ArrivalDate { get; set; }
}