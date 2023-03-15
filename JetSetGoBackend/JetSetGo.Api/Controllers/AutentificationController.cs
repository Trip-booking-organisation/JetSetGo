using JetSetGo.Application.Autentification;
using JetSetGo.Domain.User;
using JetSetGo.Infrastructure;
using JetSetGoBackend.Requests.User;
using Microsoft.AspNetCore.Mvc;

namespace JetSetGoBackend;

[ApiController]
[Route("api/v1/Autentification")]
public class AutentificationController : ControllerBase
{
    private readonly IAutentificationCommandService _autentificationCommandService;
    private readonly JetSetGoContext jetSetGoContext;

    public AutentificationController(IAutentificationCommandService autentificationCommandService,JetSetGoContext jetSetGoContext)
    {
        _autentificationCommandService = autentificationCommandService;
        this.jetSetGoContext = jetSetGoContext;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody]RegisterRequest request)
    {
        var authResult =
            _autentificationCommandService.Register(request.FirstName, request.LastName, request.Email,
                request.Password);
        jetSetGoContext.SaveChanges();
        return Ok(authResult);
    }

    [HttpGet]
    public IActionResult Proba()
    {
        var user = new User
        {
            FirstName = "Neven",
            LastName = "Neverni",
            Email = "Bla@gmail.com",
            Password = "sifra",
            Id = Guid.NewGuid()
        };
        jetSetGoContext.Users?.Add(user);
        jetSetGoContext.SaveChanges();
        return Ok();
    }
}