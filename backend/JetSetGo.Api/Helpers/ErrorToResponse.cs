using FluentResults;

namespace backend.Helpers;

public class ErrorResponse
{
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
}

public static class ErrorToResponse
{
    public static ErrorResponse ToResponse(this IEnumerable<IError> errorResults)
    {
        return new ErrorResponse
        {
            Errors = errorResults.Select(x => x.Message)
        };
    }
}