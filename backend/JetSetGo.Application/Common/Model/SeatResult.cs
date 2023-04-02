using JetSetGo.Domain.Flights.Enum;

namespace JetSetGo.Application.Common.Model;

public record SeatResult
{
    public string SeatNumber { get; set; } = null!;
    public double Price { get; set; }
    public bool Available { get; set; }
    public string Class { get; set; } = null!;
}