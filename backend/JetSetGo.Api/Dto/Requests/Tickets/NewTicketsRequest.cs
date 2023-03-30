namespace backend.Dto.Requests.Tickets;

public class NewTicketsRequest
{
    public Guid FlightId { get; set; }
    public Guid PassengerId { get; set; } 
    public List<NewTicketRequest> NewTickets { get; set; } = null!;
}