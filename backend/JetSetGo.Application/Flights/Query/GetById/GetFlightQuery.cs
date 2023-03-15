using FluentResults;
using JetSetGo.Domain.Flights;
using MediatR;

namespace JetSetGo.Application.Flights.Query.GetById;

public record GetFlightQuery(Guid Id): IRequest<Result<Flight>>;