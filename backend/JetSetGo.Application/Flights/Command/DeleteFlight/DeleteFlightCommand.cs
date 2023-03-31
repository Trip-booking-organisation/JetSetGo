using FluentResults;
using MediatR;

namespace JetSetGo.Application.Flights.Command.DeleteFlight;

public record DeleteFlightCommand(Guid Id) : IRequest<Result>;
