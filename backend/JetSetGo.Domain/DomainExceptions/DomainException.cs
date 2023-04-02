using FluentResults;

namespace JetSetGo.Domain.DomainExceptions;

public static class DomainException
{
    public static class Flight
    {
        public static IError SeatError => new Error("Seat already added");
        public static IError DateError => new Error("Departure date is after arrival");
    }
}