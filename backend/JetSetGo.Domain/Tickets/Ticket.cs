namespace JetSetGo.Domain.Tickets;

public  class Ticket
{
    public Guid Id { get; set; }
    public Guid FlightId { get; set; }
    public Guid PassengerId { get; set; } 
    public string ContactDetails { get; set; } = null!;
    public string SeatNumber { get; set; } = null!;
    public DateTime BookingTime { get; set; }
    
}