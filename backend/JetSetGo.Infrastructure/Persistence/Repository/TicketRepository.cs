using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Domain.Tickets;
using Microsoft.EntityFrameworkCore;

namespace JetSetGo.Infrastructure.Persistence.Repository;

public class TicketRepository: ITicketRepository
{
    private readonly JetSetGoContext _context;

    public TicketRepository(JetSetGoContext context)
    {
        _context = context;
    }

    public async Task<List<Ticket>> GetTicketsByPassenger(Guid id)
    {
        return await _context.Tickets
                    .Where(x => x.PassengerId == id)
                    .ToListAsync();
    }

    public Task<IEnumerable<Ticket>> GetTicketsByFlight(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Ticket?> GetTicketById(Guid id)
    {
        return _context.Tickets.FirstOrDefaultAsync(ticket => ticket.Id == id);
    }

    public async Task<Ticket?> CreateTicket(Ticket ticket)
    {
        var newTicket = await _context.Tickets.AddAsync(ticket);
        await _context.SaveChangesAsync();
        return newTicket.Entity;

    }

    public async Task UpdateTicket(Ticket ticket)
    {
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTicket(Ticket ticket)
    {
        _context.Tickets.Remove(ticket);
        await  _context.SaveChangesAsync();
    }
}