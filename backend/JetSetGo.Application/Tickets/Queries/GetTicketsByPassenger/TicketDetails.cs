using JetSetGo.Domain.Flights.ValueObjects;

namespace backend.Dto.Shared;

public class TicketDetails
{
    public string contactDetails { get; set; }
    public string seatNumber { get; set; }
    public DateTime bookingTime { get; set; }
    public FlightDetails departure { get; set; }
    public FlightDetails arrival { get; set; }



}