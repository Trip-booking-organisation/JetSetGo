using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Domain.Flights;

namespace JetSetGo.Infrastructure.Persistence.Containers;

public class FlightContainer : IFlightRepository
{
    private readonly JetSetGoContext _context;

    public FlightContainer(JetSetGoContext context)
    {
        _context = context;
    }

    public async Task<Flight?> GetById(Guid id)
    {
        var flight = await _context.Flights.FindAsync(id);
        return flight;
    }

    public async Task Create(Flight flight)
    {
        await _context.Flights.AddAsync(flight);
        await _context.SaveChangesAsync();
    }
}