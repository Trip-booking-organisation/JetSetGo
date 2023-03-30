using JetSetGo.Domain.Flights.ValueObjects;

namespace backend.Dto.Shared;

public class FlightDetailsDto
{
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public AddressDto Address { get; set; } = null!;
}