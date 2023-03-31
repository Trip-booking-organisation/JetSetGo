using JetSetGo.Application.Common.Model;
using JetSetGo.Domain.Flights;
using MediatR;

namespace JetSetGo.Application.Flights.Query.Search;

public record SearchFlightsQuery(
    string LocationFrom, 
    string LocationTo,
    int PassengersNumber,
    DateOnly Date):IRequest<IEnumerable<FlightResult>>;