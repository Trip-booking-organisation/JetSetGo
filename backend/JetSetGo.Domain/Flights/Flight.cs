namespace JetSetGo.Domain.Flights;

public class Flight
{
    public Guid Id { get; set; }
    public int NumberOfSeats { get; set; }
    public List<Ticket>? Tickets { get; set; }
}