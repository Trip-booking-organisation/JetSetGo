using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Domain.Flights;
using Microsoft.EntityFrameworkCore;

namespace JetSetGo.Infrastructure.Persistence.Containers;

public class FlightRepository : IFlightRepository
{
    private readonly JetSetGoContext _context;

    public FlightRepository(JetSetGoContext context)
    {
        _context = context;
    }

    public async Task<Flight?> GetById(Guid id)
    {
        var flight = await _context.Flights.SingleOrDefaultAsync(x => x.Id == id);
        return flight;
    }

    public async Task Create(Flight flight)
    {
        await _context.Flights.AddAsync(flight);
        await _context.SaveChangesAsync();
    }

    public async Task<Flight?> GetByIdAndSeat(Guid id, string seatNumber)
    {
        var flight = await _context.Flights
            .FirstOrDefaultAsync(flight => flight.Id == id && flight.Seats
                .Any(seat => seat.SeatNumber == seatNumber));
        return flight;
    }
}