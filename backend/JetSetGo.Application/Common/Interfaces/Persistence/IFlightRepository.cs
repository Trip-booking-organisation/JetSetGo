using JetSetGo.Domain.Flights;

namespace JetSetGo.Application.Common.Interfaces.Persistence;

public interface IFlightRepository
{
    public Task<Flight?> GetById(Guid id);
    public Task Create(Flight flight);
}