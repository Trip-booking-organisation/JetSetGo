using JetSetGo.Application.Flights.Query.Search;
using JetSetGo.Domain.DomainExceptions;
using JetSetGo.Domain.Flights;

namespace JetSetGo.Application.Common.Interfaces.Persistence;

public interface IFlightRepository
{
    Task<Flight?> GetById(Guid id);
    Task<Guid> Create(Flight flight,CancellationToken cancellationToken);
    Task<List<Flight>> SearchFlights(SearchFlightsQuery flightsQuery,CancellationToken cancellationToken);
    Task<List<Flight>> GetAllFlights(CancellationToken cancellationToken);
    Task Update(Flight flight);
    Task Delete(Flight flight);

}