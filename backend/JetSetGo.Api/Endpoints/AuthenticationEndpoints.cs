﻿using backend.Dto.Requests.User;
using JetSetGo.Application.Autentification.Command.Register;
using JetSetGo.Application.Autentification.Query.SignIn;
using MediatR;

namespace backend.Endpoints;

public static class AuthenticationEndpoints
{
    public static void MapAuthenticationEndpoints(this WebApplication application)
    {
        application.MapGet("authentication/users", GetAllUsers).RequireAuthorization("AdminPolicy");
        application.MapPost("authentication/register", Register);
        application.MapPost("authentication/signIn", SignIn).AllowAnonymous();
    }

    private static async Task<IResult> GetAllUsers(ISender sender)
    {
        await Task.CompletedTask;
        return Results.Ok("Uspesno");
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