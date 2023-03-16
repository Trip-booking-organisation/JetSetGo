using JetSetGo.Application.Common.Services;

namespace JetSetGo.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow  => DateTime.UtcNow;
}