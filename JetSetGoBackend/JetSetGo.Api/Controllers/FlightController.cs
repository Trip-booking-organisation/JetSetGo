using JetSetGo.Domain;
using JetSetGo.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JetSetGoBackend;
[Route("api/v1/[controller]")]
[ApiController]
public class FlightController : ControllerBase
{
    private readonly JetSetGoContext jetSetGoContext;

    public FlightController(JetSetGoContext jetSetGoContext)
    {
        this.jetSetGoContext = jetSetGoContext;
    }

    [HttpGet]
    public IActionResult Proba()
    {
        var ticket1 = new Ticket()
        {
            Price = 100,
            Id = Guid.NewGuid().ToString()
        };
        var ticket2 = new Ticket()
        {
            Price = 200,
            Id = Guid.NewGuid().ToString()
        };
        List<Ticket> tickets = new List<Ticket>();
        tickets.Add(ticket1);
        tickets.Add(ticket2);
        var flight1 = new Flight()
        {
            Id = Guid.NewGuid().ToString(),
            NumberOfSeats = 500,
            Tickets = tickets
        };
        jetSetGoContext.Flights?.Add(flight1);
        jetSetGoContext.SaveChanges();
        return Ok();
    }
    
}