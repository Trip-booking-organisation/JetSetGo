using FluentResults;
using JetSetGo.Domain.Flights.Enum;
using MediatR;

namespace JetSetGo.Application.Flights.Command.CreateFlight;

public record CreateFlightCommand : IRequest<Result<Guid>>
{
    public List<SeatCommand> Seats { get; set; } = null!;
    public DetailCommand Departure { get; set; } = null!;
    public DetailCommand Arrival { get; set; } = null!;
    public string CompanyName { get; set; } = null!;
    public record DetailCommand
    {
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public AddressCommand Address { get; set; } = null!;
    }

    public record SeatCommand
    {
        public string SeatNumber { get; set; } = null!;
        public double Price { get; set; }
        public bool Available { get; set; }
        public SeatClass Class { get; set; }
    }
    public record AddressCommand
    {
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string AirportName { get; set; } = null!;
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}