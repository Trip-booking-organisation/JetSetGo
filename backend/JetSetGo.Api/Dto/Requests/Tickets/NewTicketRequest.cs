namespace backend.Dto.Requests.Tickets;

public class NewTicketRequest
{
  
    public string ContactDetails { get; set; } = null!;
    public string SeatNumber { get; set; } = null!;
}