using AutoMapper;
using backend.Requests.Tickets;
using JetSetGo.Application.Tickets.Commands.CreateNewTicket;
using JetSetGo.Domain.Tickets;

namespace backend.Mapping;

public class AutoMappingConfig : Profile
{
    public AutoMappingConfig()
    {
        CreateMap<NewTicketRequest, NewTicketCommand>();
    }
}