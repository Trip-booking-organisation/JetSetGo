using FluentResults;
using JetSetGo.Application.Common.Errors;
using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Domain.ApiKeys;
using JetSetGo.Domain.Flights;
using JetSetGo.Domain.Tickets;
using MediatR;

namespace JetSetGo.Application.Tickets.Commands.CreateNewTicket;

public class NewTicketCommandHandler : IRequestHandler<NewTicketsCommand,Result<bool>>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IFlightRepository _flightRepository;
    private readonly IUserRepository _userRepository;
    private readonly IApikeyRepository _apikeyRepository;

    public NewTicketCommandHandler(ITicketRepository ticketRepository, IFlightRepository flightRepository, IUserRepository userRepository, IApikeyRepository apikeyRepository)
    {
        _ticketRepository = ticketRepository;
        _flightRepository = flightRepository;
        _userRepository = userRepository;
        _apikeyRepository = apikeyRepository;
    }

    public async Task<Result<bool>> Handle(NewTicketsCommand request, CancellationToken cancellationToken)
    {
        var newTickets = new List<Ticket>();
        if (newTickets == null) throw new ArgumentNullException(nameof(newTickets));
        var flight = await CheckIfFlightExists(request);
        if (flight == null) return Result.Fail<bool>(FlightErrors.FlightNotFound);
        if(flight.AvailableSeats < request.NewTickets.Count) return Result.Fail<bool>(FlightErrors.NoAvailableSeats);
        if (await CheckIfPassengerExists(request)) return Result.Fail<bool>(UserErrors.UserNotFound);
       
        foreach (var ticket in request.NewTickets)
        {
            if (!CheckIfSeatExistsOnFlight(flight,ticket.SeatNumber)) return Result.Fail<bool>(SeatErrors.SeatNotFound);
            var newTicket = await CreateTicket(ticket,request);
            if (newTicket is null)
            {
                return  Result.Fail<bool>(TicketErrors.TicketNotCreated);
            }
            await UpdateSeatAvailability(ticket, flight);
            newTickets.Add(newTicket);
        }

        return Result.Ok(newTickets.Any());
    }
    private async Task UpdateSeatAvailability(NewTicketCommand request, Flight flight)
    {
            flight.Seats.ForEach(seat =>
            {
                if (seat.SeatNumber == request.SeatNumber) seat.Available = false;
            });
            --flight.AvailableSeats; 
            await _flightRepository.Update(flight);
    }

    private async Task<Ticket?> CreateTicket(NewTicketCommand ticket, NewTicketsCommand request)
    {
        var ticketRequest = await InitializeTicket(ticket,request);
        if (ticketRequest is null)
            return null;
        var newTicket = await _ticketRepository.CreateTicket(ticketRequest);
        return newTicket;
    }

    private async Task<Ticket?> InitializeTicket(NewTicketCommand ticket, NewTicketsCommand request)
    {
        if (request.ApiKey is null)
        {
            var ticketRequest = new Ticket
            {
                SeatNumber = ticket.SeatNumber,
                BookingTime = DateTime.Now,
                ContactDetails = ticket.ContactDetails,
                PassengerId = request.PassengerId,
                FlightId = request.FlightId
            };

            return ticketRequest;
        }
        var apiKeySplit = request.ApiKey.Split(new string[] { "==" }, StringSplitOptions.None);
        if (!await ValidateApiKey(apiKeySplit)) return null;
        {
            var ticketRequest = new Ticket
            {
                SeatNumber = ticket.SeatNumber,
                BookingTime = DateTime.Now,
                ContactDetails = ticket.ContactDetails,
                PassengerId = Guid.Parse(apiKeySplit[1]),
                FlightId = request.FlightId
            };
            return ticketRequest;
        }

    }

    private async Task<bool> ValidateApiKey(IReadOnlyList<string> apiKeySplit)
    {
        var apiKey = await _apikeyRepository.GetByToken(Guid.Parse(apiKeySplit[0]));
        if(apiKey is null)
            return false;
        
        if (CheckExpirationDate(apiKey))
            return false;
            
        return apiKey.UserId.ToString() == apiKeySplit[1];
    }

    private  bool CheckExpirationDate(ApiKey apiKey)
    {
        if (apiKey.HasExpiration)
            return apiKey.ExpirationDate < DateTime.Now;
        return true;
    }

    private bool CheckIfSeatExistsOnFlight(Flight flight,String seatNumber)
    {
        if (flight.AvailableSeats > 0)
        {
            var seat = flight
                .Seats
                .FirstOrDefault(seat => seat.SeatNumber == seatNumber && seat.Available);
            return seat != null;
        }
       
        return false;
    }

    private async Task<bool> CheckIfPassengerExists(NewTicketsCommand request)
    {
        var passenger = await _userRepository
                                    .GetById(request.PassengerId);
        return passenger == null;
    }

    private async Task<Flight?> CheckIfFlightExists(NewTicketsCommand request)
    {
        var flight = await _flightRepository
                                .GetById(request.FlightId);
        return flight;
    }
}