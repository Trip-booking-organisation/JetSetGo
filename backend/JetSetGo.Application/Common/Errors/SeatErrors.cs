using FluentResults;

namespace JetSetGo.Application.Common.Errors;

public class SeatErrors
{
    public static IError SeatNotFound=> new Error("Seat not found on the flight!");
}