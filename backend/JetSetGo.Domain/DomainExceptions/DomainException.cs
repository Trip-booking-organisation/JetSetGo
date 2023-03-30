using FluentResults;

namespace JetSetGo.Domain.DomainExceptions;

public static class DomainException
{
    public static class Flight
    {
        public static IError SeatError => new Error("Seat already added");
    }
}