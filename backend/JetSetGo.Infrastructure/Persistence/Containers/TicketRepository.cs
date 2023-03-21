using JetSetGo.Application.Common.Interfaces.Tickets;
using JetSetGo.Domain.Tickets;
using Microsoft.EntityFrameworkCore;

namespace JetSetGo.Infrastructure.Persistence.Containers;

public class TicketRepository: ITicketRepository
{
    private readonly JetSetGoContext _context;

    public TicketRepository(JetSetGoContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Ticket>> GetTicketsByPassenger(Guid id)
    {
        return await _context.Tickets
                    .Where(x => x.PassengerId == id)
                    .ToListAsync();
    }

    public Task<IEnumerable<Ticket>> GetTicketsByFlight(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Ticket> GetTicketById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task CreateTicket(Ticket ticket)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTicket(Ticket ticket)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTicket(Guid id)
    {
        throw new NotImplementedException();
    }
}