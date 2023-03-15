namespace JetSetGo.Domain;

public class Flight
{
    public String Id { get; set; }
    public int NumberOfSeats { get; set; }
    public List<Ticket>? Tickets { get; set; }
}