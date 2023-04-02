using FluentResults;
using JetSetGo.Application.Common.Errors;
using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Domain.Flights;
using JetSetGo.Domain.Tickets;
using MediatR;

namespace JetSetGo.Application.Tickets.Commands.CreateNewTicket;

public class NewTicketCommandHandler : IRequestHandler<NewTicketsCommand,Result<bool>>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IFlightRepository _flightRepository;
    private readonly IUserRepository _userRepository;

    public NewTicketCommandHandler(ITicketRepository ticketRepository, IFlightRepository flightRepository, IUserRepository userRepository)
    {
        _ticketRepository = ticketRepository;
        _flightRepository = flightRepository;
        _userRepository = userRepository;
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
        var ticketRequest = InitializeTicket(ticket,request);
        var newTicket = await _ticketRepository.CreateTicket(ticketRequest);
        return newTicket;
    }

    private static Ticket InitializeTicket(NewTicketCommand ticket, NewTicketsCommand request)
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