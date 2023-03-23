﻿using FluentResults;
using JetSetGo.Application.Common.Interfaces.Autentification;
using JetSetGo.Application.Flights.Query.GetById;
using JetSetGo.Application.Persistence;
using JetSetGo.Domain.Users;
using MediatR;
using Microsoft.Extensions.Logging;

namespace JetSetGo.Application.Autentification.Command.Register;

public record RegisterCommandHandler: IRequestHandler<RegisterCommand,Result<AutentificationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<GetFlightQueryHandler> _logger;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;


    public RegisterCommandHandler(IUserRepository userRepository, ILogger<GetFlightQueryHandler> logger, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _logger = logger;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<Result<AutentificationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (!await CheckEmail(request.Email))
        {
            return Result.Fail("Wrong credentials");
        }
        
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, request.FirstName, request.LastName,request.Email);
        var user = new User
        {
            Id = userId,
            FirstName = request.FirstName, 
            LastName = request.LastName, 
            Email = request.Email, 
            Password = request.Password
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