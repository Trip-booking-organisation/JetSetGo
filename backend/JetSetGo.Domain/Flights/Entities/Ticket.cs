using JetSetGo.Domain.Flights.Enum;

namespace JetSetGo.Domain.Flights.Entities;

public  class Ticket
{
    public Guid Id { get; set; }
    public int Price { get; set; }
    public Class Class { get; set; }
}