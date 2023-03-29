using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Application.Flights.Query.Search;
using JetSetGo.Domain.Flights;
using Microsoft.EntityFrameworkCore;

namespace JetSetGo.Infrastructure.Persistence.Repository;

public class FlightRepository : IFlightRepository
{
    private readonly JetSetGoContext _context;

    public FlightRepository(JetSetGoContext context)
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

    public async Task<List<Flight>> SearchFlights(SearchFlightsQuery flightsQuery)
    {
        var query = await _context.Flights
            .Where(f => f.Departure.Date == flightsQuery.Date
            )
            .ToListAsync();
        return query;
    }
}