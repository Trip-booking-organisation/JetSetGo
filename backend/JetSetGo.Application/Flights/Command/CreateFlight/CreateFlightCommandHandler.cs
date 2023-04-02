using FluentResults;
using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Application.Converters;
using JetSetGo.Domain.DomainExceptions;
using JetSetGo.Domain.Flights;
using JetSetGo.Domain.Flights.Entities;
using JetSetGo.Domain.Flights.Enum;
using JetSetGo.Domain.Flights.ValueObjects;
using MediatR;
using Microsoft.Extensions.Logging;

namespace JetSetGo.Application.Flights.Command.CreateFlight;

public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand,Result<Guid>>
{
    private readonly IFlightRepository _flightRepository;
    private readonly ILogger<CreateFlightCommandHandler> _logger;

    public CreateFlightCommandHandler(IFlightRepository flightRepository,
        ILogger<CreateFlightCommandHandler> logger)
    {
        _flightRepository = flightRepository;
        _logger = logger;
    }

    public async Task<Result<Guid>> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"{request.ToString()} is sended");
        var arrival = new FlightDetails
        {
            Date = request.Arrival.Date,
            Time = request.Arrival.Time,
            Address = new Address
            {
                City = request.Arrival.Address.City,
                Country = request.Arrival.Address.Country,
                AirportName = request.Arrival.Address.AirportName,
                Longitude = request.Arrival.Address.Longitude,
                Latitude = request.Arrival.Address.Latitude
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
                Longitude = request.Departure.Address.Longitude,
                Latitude = request.Departure.Address.Latitude
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

        var flight = new Flight(seats, departure, arrival,request.CompanyName);
        var resultValidation = flight.Validate();
        if (resultValidation.IsFailed)
        {
            _logger.LogError($"{resultValidation.Errors[0].Message} error occurs");
            return resultValidation;
        }
        var id = await _flightRepository.Create(flight,cancellationToken);
        return id;
    }
}