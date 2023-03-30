using AutoMapper;
using backend.Dto.Requests.Flights;
using backend.Dto.Requests.Tickets;
using backend.Dto.Shared;
using JetSetGo.Application.Flights.Command.CreateFlight;
using JetSetGo.Application.Tickets.Commands.CreateNewTicket;
using JetSetGo.Domain.Tickets;

namespace backend.Mapping;

public class AutoMappingConfig : Profile
{
    public AutoMappingConfig()
    {
        CreateMap<NewTicketRequest, NewTicketCommand>();
        CreateMap<SeatDto, CreateFlightCommand.SeatCommand>();
        CreateMap<FlightDetailsDto, CreateFlightCommand.DetailCommand>();
        CreateMap<AddressDto, CreateFlightCommand.AddressCommand>();
        CreateMap<CreateFlight, CreateFlightCommand>()
            .ForMember(dest => dest.Seats, 
                opt => opt.MapFrom(src => src.Seats))
            .ForMember(dest => dest.Departure,
                opt => opt.MapFrom(src => src.Departure))
            .ForMember(dest => dest.Arrival,
                opt => opt.MapFrom(src => src.Arrival));
    }
}