using backend.Dto.Shared;

namespace backend.Dto.Requests.Flights;

public class CreateFlight
{
    public List<SeatDto> Seats { get; set; } = null!;
    public FlightDetailsDto Departure { get; set; } = null!;
    public FlightDetailsDto Arrival { get; set; } = null!;
    public int AvailableSeats { get; set; }
}