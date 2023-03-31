using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Application.Flights.Query.Search;
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

    public async Task<Guid> Create(Flight flight)
    {
        var entityEntry = await _context.Flights.AddAsync(flight);
        await _context.SaveChangesAsync();
        return entityEntry.Entity.Id;
    }

    public async Task<List<Flight>> SearchFlights(SearchFlightsQuery flightsQuery)
    {
        var query =  _context.Flights
            .Where(f => f.Departure.Date == flightsQuery.Date
            && f.AvailableSeats >= flightsQuery.PassengersNumber
            );
        // var flights = _context.Flights.FromSqlRaw(@"
        //     SELECT DISTINCT c
        //     FROM c
        //     JOIN s IN c.Seats
        //     WHERE s.Available = true"
        // );
        // _logger.LogInformation(flights.ToQueryString());
        return await query.ToListAsync();
    }

    public async Task Update(Flight flight)
    {
        _context.Flights.Update(flight);
      await  _context.SaveChangesAsync();
    }
}