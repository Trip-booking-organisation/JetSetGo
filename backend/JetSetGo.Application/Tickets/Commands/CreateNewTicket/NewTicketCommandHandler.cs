using FluentResults;
using JetSetGo.Application.Common.Errors;
using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Domain.Flights;
using JetSetGo.Domain.Flights.Entities;
using JetSetGo.Domain.Flights.Enum;
using JetSetGo.Domain.Flights.ValueObjects;
using JetSetGo.Domain.Tickets;
using MediatR;

namespace JetSetGo.Application.Tickets.Commands.CreateNewTicket;

public class NewTicketCommandHandler : IRequestHandler<NewTicketCommand,Result<Ticket>>
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

    public async Task<Result<Ticket>> Handle(NewTicketCommand request, CancellationToken cancellationToken)
    {
        
        if (await CheckIfFlightExists(request)) return Result.Fail<Ticket>(FlightErrors.FlightNotFound);
        if (await CheckIfPassengerExists(request)) return Result.Fail<Ticket>(UserErrors.UserNotFound);
        //if (await CheckIfSeatExistsOnFlight(request)) return Result.Fail<Ticket>(SeatErrors.SeatNotFound);
        
        var ticketRequest = InitializeTicket(request);
        var newTicket = await  _ticketRepository.CreateTicket(ticketRequest);
        
        return newTicket ?? Result.Fail<Ticket>(TicketErrors.TicketNotCreated);
    }

    private static Ticket InitializeTicket(NewTicketCommand request)
    {
        var ticketRequest = new Ticket
        {
            SeatNumber = request.SeatNumber,
            BookingTime = new DateTime(),
            ContactDetails = request.ContactDetails,
            PassengerId = request.PassengerId,
            FlightId = request.FlightId
        };
        return ticketRequest;
    }

    private async Task CheckIfSeatExistsOnFlight(NewTicketCommand request)
    {
        /*var flight = await _flightRepository.GetByIdAndSeat(request.FlightId,request.SeatNumber);
        return flight == null;*/
    }

    private async Task<bool> CheckIfPassengerExists(NewTicketCommand request)
    {
        var passenger = await _userRepository.GetById(request.PassengerId);
        return passenger == null;
    }

    private async Task<bool> CheckIfFlightExists(NewTicketCommand request)
    {
        var flight = await _flightRepository.GetById(request.FlightId);
        return flight == null;
    }
}