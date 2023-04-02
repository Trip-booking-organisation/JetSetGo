using FluentResults;
using JetSetGo.Domain.Common.BuildingBlocks;

namespace JetSetGo.Domain.Flights.ValueObjects;

public class FlightDetails: ValueObject
{
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public Address Address { get; set; } = null!;
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Time;
        yield return Date;
        yield return Address;
    }

    public bool IsAfterDate(FlightDetails another)
    {
        if (another.Date > Date)
        {
            return false;
        }
        if (another.Date == Date && another.Time < Time)
        {
            return false;
        }
        return true;
    }
}