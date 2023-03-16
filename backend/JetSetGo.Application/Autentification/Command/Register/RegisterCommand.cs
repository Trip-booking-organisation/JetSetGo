using FluentResults;
using JetSetGo.Domain.Users;
using MediatR;

namespace JetSetGo.Application.Autentification.Command;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<Result<AutentificationResult>>;

