using JetSetGo.Domain.Flights.Enum;

namespace backend.Dto.Shared;

public class SeatDto
{
    public string SeatNumber { get; set; } = null!;
    public double Price { get; set; }
    public bool Available { get; set; }
    public SeatClass Class { get; set; }
}