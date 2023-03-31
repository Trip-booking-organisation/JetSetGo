using FluentResults;

namespace JetSetGo.Application.Common.Errors;

public static class FlightErrors
{
    public static IError FlightNotFound => new Error("Flight not found");
    public static IError NoAvailableSeats => new Error("Flight doesn't have enough available seats");
}