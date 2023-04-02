using FluentResults;

namespace JetSetGo.Application.Common.Errors;

public static class UserErrors
{
    public static IError UserNotFound=> new Error("User not found");
}