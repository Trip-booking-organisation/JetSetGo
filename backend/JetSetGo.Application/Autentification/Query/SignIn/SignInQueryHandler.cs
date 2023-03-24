using FluentResults;
using JetSetGo.Application.Common.Interfaces.Autentification;
using JetSetGo.Application.Flights.Query.GetById;
using JetSetGo.Application.Persistence;
using JetSetGo.Domain.Users;
using MediatR;
using Microsoft.Extensions.Logging;

namespace JetSetGo.Application.Autentification.Query.SignIn;

public class SignInQueryHandler : IRequestHandler<SignInQuery, Result<AutentificationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<GetFlightQueryHandler> _logger;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public SignInQueryHandler(IUserRepository userRepository, ILogger<GetFlightQueryHandler> logger, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _logger = logger;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<Result<AutentificationResult>> Handle(SignInQuery request, CancellationToken cancellationToken)
    {
        var user =await  _userRepository.GetByEmail(request.Email);
        if (user == null)
        {
            return Result.Fail("Email or password is invalid.");
        }

        if (!CheckPassword(user, request.Password))
        {
            return Result.Fail("Email or password is invalid.");
        }
        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName,user.Email,user.Role);
        return  new AutentificationResult(token);
    }

    private bool CheckPassword(User user, string password)
    {
        return user.Password == password;
    }
}