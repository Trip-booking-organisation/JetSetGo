using FluentResults;

namespace JetSetGo.Application.Common.Errors;

public static class FlightErrors
{
    public static IError FlightNotFound => new Error("Flight not found");
}