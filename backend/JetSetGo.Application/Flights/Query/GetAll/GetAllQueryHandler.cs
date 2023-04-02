using FluentResults;
using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Application.Common.Model;
using JetSetGo.Application.Flights.Mapper;
using MediatR;

namespace JetSetGo.Application.Flights.Query.GetAll;

public class GetAllQueryHandler: IRequestHandler<GetAllQuery,List<FlightResult>>
{
    private readonly IFlightRepository _flightRepository;

    public GetAllQueryHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<List<FlightResult>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var list = await _flightRepository.GetAllFlights(cancellationToken);
        var flightResults = list.Select(FlightMapper.MapFlightToResult).ToList();
        return flightResults;
    }
}