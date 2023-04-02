using FluentResults;
using JetSetGo.Application.Common.Interfaces.Autentification;
using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Application.Flights.Query.GetById;
using JetSetGo.Domain.Users;
using MediatR;
using Microsoft.Extensions.Logging;

namespace JetSetGo.Application.Autentification.Command.Register;

public record RegisterCommandHandler: IRequestHandler<RegisterCommand,Result<AutentificationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<GetFlightQueryHandler> _logger;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordHasher _passwordHasher;


    public RegisterCommandHandler(IUserRepository userRepository, ILogger<GetFlightQueryHandler> logger, IJwtTokenGenerator jwtTokenGenerator,IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _logger = logger;
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<AutentificationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (!await CheckEmail(request.Email))
        {
            return Result.Fail("Wrong credentials");
        }

        var hashedPassword = _passwordHasher.Hash(request.Password);
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, request.FirstName, request.LastName,request.Email,UserRole.Passenger);
        var user = new User
        {
            Id = userId,
            FirstName = request.FirstName, 
            LastName = request.LastName, 
            Email = request.Email, 
            Password = hashedPassword,
            Role = UserRole.Passenger
        };
        await _userRepository.CreateAsync(user);
        return  new AutentificationResult(token);
    }
    
    private async Task<Boolean> CheckEmail(string email)
    {
        var user = await _userRepository.GetByEmail(email);
        if (user != null)
        {
            return false;
        }
        return true;
    }
}