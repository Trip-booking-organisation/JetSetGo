using JetSetGo.Domain.Tickets;

namespace JetSetGo.Application.Common.Interfaces.Tickets;

public interface ITicketRepository
{
    Task<IEnumerable<Ticket>> GetTicketsByPassenger(Guid id);
    Task<IEnumerable<Ticket>> GetTicketsByFlight(Guid id);
    Task<Ticket> GetTicketById(Guid id);
    Task CreateTicket(Ticket ticket);
    Task UpdateTicket(Ticket ticket);
    Task DeleteTicket(Guid id);
}