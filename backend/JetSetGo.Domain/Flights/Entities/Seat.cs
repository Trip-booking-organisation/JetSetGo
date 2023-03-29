using JetSetGo.Domain.Flights.Enum;

namespace JetSetGo.Domain.Flights.Entities;

public class Seat
{
    public string SeatNumber { get; set; } = null!;
    public double Price { get; set; }
    public bool Available { get;  private set; }
    public SeatClass Class { get; set; }

    public void UpdateAvailability(bool available)
    {
        Available = available;
    }
}