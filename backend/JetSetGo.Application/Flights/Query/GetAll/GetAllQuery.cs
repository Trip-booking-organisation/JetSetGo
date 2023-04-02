using JetSetGo.Application.Common.Model;
using MediatR;

namespace JetSetGo.Application.Flights.Query.GetAll;

public record GetAllQuery(int Limit) :IRequest<List<FlightResult>>;