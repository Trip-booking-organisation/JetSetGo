namespace backend.Dto.Shared;

public class AddressDto
{
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string AirportName { get; set; } = null!;
    public double Longitude { get; set; }
    public double Latitude { get; set; }
}