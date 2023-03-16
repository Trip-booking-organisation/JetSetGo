using FluentResults;
using MediatR;

namespace JetSetGo.Application.Autentification.Command.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<Result<AutentificationResult>>;

