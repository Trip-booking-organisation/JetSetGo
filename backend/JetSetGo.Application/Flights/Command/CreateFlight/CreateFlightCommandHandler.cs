using FluentResults;
using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Domain.DomainExceptions;
using JetSetGo.Domain.Flights;
using JetSetGo.Domain.Flights.Entities;
using JetSetGo.Domain.Flights.Enum;
using JetSetGo.Domain.Flights.ValueObjects;
using MediatR;

namespace JetSetGo.Application.Flights.Command.CreateFlight;

public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand,Result<Guid>>
{
    private readonly IFlightRepository _flightRepository;

    public CreateFlightCommandHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<Result<Guid>> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var arrival = new FlightDetails
        {
            Date = request.Arrival.Date,
            Time = request.Arrival.Time,
            Address = new Address
            {
                City = request.Arrival.Address.City,
                Country = request.Arrival.Address.Country,
                AirportName = request.Arrival.Address.AirportName,
            }
        };
        var departure = new FlightDetails
        {
            Date = request.Departure.Date,
            Time = request.Departure.Time,
            Address = new Address
            {
                City = request.Departure.Address.City,
                Country = request.Departure.Address.Country,
                AirportName = request.Departure.Address.AirportName,
            }
        };
        var seats = request.Seats.
            Select(s => new Seat
            {
                SeatNumber = s.SeatNumber,
                Price = s.Price,
                Available = s.Available,
                Class = s.Class
            }).ToList();
        var seatsValidation = Flight.ValidateSets(seats);
        if (seatsValidation.IsFailed)
        {
            return Result.Fail<Guid>("Same seat provided");
        }

        var flight = new Flight(seats, departure, arrival);
        var id = await _flightRepository.Create(flight);
        return id;
    }
}