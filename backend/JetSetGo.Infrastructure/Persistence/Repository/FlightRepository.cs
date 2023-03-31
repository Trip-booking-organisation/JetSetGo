using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Application.Flights.Query.Search;
using JetSetGo.Domain.DomainExceptions;
using JetSetGo.Domain.Flights;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JetSetGo.Infrastructure.Persistence.Repository;

public class FlightRepository : IFlightRepository
{
    private readonly JetSetGoContext _context;
    private ILogger<FlightRepository> _logger;

    public FlightRepository(JetSetGoContext context, ILogger<FlightRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Flight?> GetById(Guid id)
    {
        var flight = await _context.Flights.FindAsync(id);
        return flight;
    }

    public async Task<Guid> Create(Flight flight,CancellationToken cancellationToken = default)
    {
        var entityEntry = await _context.Flights.AddAsync(flight,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entityEntry.Entity.Id;
    }

    public async Task<List<Flight>> SearchFlights(SearchFlightsQuery flightsQuery,CancellationToken cancellationToken = default)
    {
        var query =  _context.Flights
            .Where(f => f.Departure.Date == flightsQuery.Date
            && f.AvailableSeats >= flightsQuery.PassengersNumber
            );
        return await query.ToListAsync(cancellationToken);
    }

    public async Task Update(Flight flight)
    {
        _context.Flights.Update(flight);
      await  _context.SaveChangesAsync();
    }

    public async Task Delete(Flight flight)
    {
        _context.Flights.Remove(flight);
        await _context.SaveChangesAsync();

    }
}