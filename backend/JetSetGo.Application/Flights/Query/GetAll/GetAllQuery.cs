using JetSetGo.Application.Common.Model;
using MediatR;

namespace JetSetGo.Application.Flights.Query.GetAll;

public record GetAllQuery :IRequest<List<FlightResult>>;