using FluentResults;
using JetSetGo.Application.Common.Interfaces.Autentification;
using JetSetGo.Application.Common.Interfaces.Persistence;
using MediatR;

namespace JetSetGo.Application.Autentification.Query.SignIn;

public class SignInQueryHandler : IRequestHandler<SignInQuery, Result<AutentificationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordHasher _passwordHasher;

    public SignInQueryHandler(IUserRepository userRepository, 
        IJwtTokenGenerator jwtTokenGenerator, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<AutentificationResult>> Handle(SignInQuery request, CancellationToken cancellationToken)
    {
        var user =await  _userRepository.GetByEmail(request.Email);
        if (user == null)
        {
            return Result.Fail("Email or password is invalid.");
        }

        if (!_passwordHasher.Verify(user.Password,request.Password))
        {
            return Result.Fail("Email or password is invalid.");
        }
        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName,user.Email,user.Role);
        return  new AutentificationResult(token);
    }
    
}