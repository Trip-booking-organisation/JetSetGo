using FluentResults;
using JetSetGo.Application.Common.Errors;
using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Domain.Tickets;
using MediatR;

namespace JetSetGo.Application.Tickets.Queries.GetTicketsByPassenger;

public class GetTicketsByPassengerHandler: IRequestHandler<GetTicketsByPassengerQuery,Result<List<TicketDetails>>>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUserRepository _userRepository;
    private readonly IFlightRepository _flightRepository;

    public GetTicketsByPassengerHandler(ITicketRepository ticketRepository, IUserRepository userRepository, IFlightRepository flightRepository)
    {
        _ticketRepository = ticketRepository;
        _userRepository = userRepository;
        _flightRepository = flightRepository;
    }

    public async Task<List<TicketDetails>> CreateTicketDetailsList(List<Ticket> ticketsList)
    {
        var ticketDetailList = new List<TicketDetails>();
        foreach (var ticket in ticketsList)
        {
            var ticket1 = await CreateTicketDetails(ticket);
            ticketDetailList.Add(ticket1);
        }

        return ticketDetailList;
    }

    public async Task<TicketDetails> CreateTicketDetails(Ticket ticket)
    {
        var flight = await _flightRepository.GetById(ticket.FlightId);
        if (flight is null)
        {
            return new TicketDetails();
        }
        var ticketDetail = new TicketDetails
        {
            Arrival = flight.Arrival,
            Departure = flight.Departure,
            SeatNumber = ticket.SeatNumber,
            BookingTime = ticket.BookingTime,
            ContactDetails = ticket.ContactDetails
        };
        return ticketDetail;
    }

    public async Task<Result<List<TicketDetails>>> Handle(GetTicketsByPassengerQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.Id);
        if (user == null) return Result.Fail(UserErrors.UserNotFound);
        var tickets = await _ticketRepository.GetTicketsByPassenger(request.Id);
        var result = await CreateTicketDetailsList(tickets);
        return result.Any() ? result : Result.Fail<List<TicketDetails>>(TicketErrors.TicketsNotFound);
    }
}