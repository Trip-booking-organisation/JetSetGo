using backend.Dto.Shared;
using MediatR;

namespace backend.Dto.Requests.Flights;

public class CreateFlight
{
    public List<SeatDto> Seats { get; set; } = null!;
    public FlightDetailsDto Departure { get; set; } = null!;
    public FlightDetailsDto Arrival { get; set; } = null!;
}