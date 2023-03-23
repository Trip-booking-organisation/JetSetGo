using JetSetGo.Domain.Tickets;

namespace JetSetGo.Application.Common.Interfaces.Persistence;

public interface ITicketRepository
{
    Task<List<Ticket>> GetTicketsByPassenger(Guid id);
    Task<IEnumerable<Ticket>> GetTicketsByFlight(Guid id);
    Task<Ticket?> GetTicketById(Guid id);
    Task CreateTicket(Ticket ticket);
    Task UpdateTicket(Ticket ticket);
    Task DeleteTicket(Ticket ticket);
}