using JetSetGo.Domain.Common.BuildingBlocks;

namespace JetSetGo.Domain.Flights.ValueObjects;

public class Address : ValueObject
{
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string AirportName { get; set; } = null!;
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return Country;
        yield return AirportName;
    }
}