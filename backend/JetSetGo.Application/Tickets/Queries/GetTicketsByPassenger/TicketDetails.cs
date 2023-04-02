using JetSetGo.Domain.Flights.ValueObjects;

namespace JetSetGo.Application.Tickets.Queries.GetTicketsByPassenger;

public class TicketDetails
{
    public string ContactDetails { get; set; } = null!;
    public string SeatNumber { get; set; } = null!;
    public DateTime BookingTime { get; set; }
    public FlightDetails Departure { get; set; } = null!;
    public FlightDetails Arrival { get; set; } = null!;
}