using backend.Requests.User;
using JetSetGo.Application.Autentification.Command;
using JetSetGo.Application.Autentification.Command.Register;
using JetSetGo.Application.Autentification.Query.SignIn;
using MediatR;

namespace backend.Endpoints;

public static class AuthenticationEndpoints
{
    public static void MapAuthenticationEndpoints(this WebApplication application)
    {
        application.MapGet("authentification/users", GetAllUsers);
        application.MapPost("authentification/register", Register);
        application.MapPost("authentification/signIn", SignIn);
    }

    private static async Task<IResult> GetAllUsers(ISender sender)
    {
        await Task.CompletedTask;
        return Results.Ok();
    }

    private static async Task<IResult> SignIn(ISender sender, SignInRequest request)
    {
        var signInQuery = new SignInQuery(
            request.Email,
            request.Password);
        var loggedUser = await sender.Send(signInQuery);
        return loggedUser.IsFailed ? Results.Problem("Bad credentials") : Results.Ok(loggedUser.Value);
    }
    private static async Task<IResult> Register(ISender sender,RegisterRequest request)
    {
        var registerCommand = new RegisterCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );
        var newUser = await sender.Send(registerCommand);
        return newUser.IsFailed ? Results.Problem("Bad credentials") : Results.Ok(newUser.Value);
    }
}