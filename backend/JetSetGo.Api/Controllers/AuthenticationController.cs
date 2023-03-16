using backend.Requests.User;
using JetSetGo.Application.Autentification;
using JetSetGo.Domain.Users;
using JetSetGo.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/v1/Authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IAutentificationCommandService _autentificationCommandService;
    private readonly JetSetGoContext jetSetGoContext;

    public AuthenticationController(IAutentificationCommandService autentificationCommandService,JetSetGoContext jetSetGoContext)
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