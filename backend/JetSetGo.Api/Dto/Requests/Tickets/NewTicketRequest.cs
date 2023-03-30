namespace backend.Dto.Requests.Tickets;

public class NewTicketRequest
{
    public Guid FlightId { get; set; }
    public Guid PassengerId { get; set; } 
    public string ContactDetails { get; set; } = null!;
    public string SeatNumber { get; set; } = null!;
}