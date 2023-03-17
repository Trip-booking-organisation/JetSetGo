using FluentResults;
using MediatR;

namespace JetSetGo.Application.Autentification.Query.SignIn;

public record SignInQuery
(
    string Email,
    string Password) : IRequest<Result<AutentificationResult>>;