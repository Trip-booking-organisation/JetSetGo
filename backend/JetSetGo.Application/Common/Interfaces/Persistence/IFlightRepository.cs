using JetSetGo.Domain.Flights;

namespace JetSetGo.Application.Common.Interfaces.Persistence;

public interface IFlightRepository
{
     Task<Flight?> GetById(Guid id);
     Task Create(Flight flight);
     Task<Flight?> GetByIdAndSeat(Guid id, string seatNumber);
}