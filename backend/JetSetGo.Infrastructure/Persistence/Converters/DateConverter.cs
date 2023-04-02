using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JetSetGo.Infrastructure.Persistence.Converters;

public class DateConverter: ValueConverter<DateOnly, string>
{
    public DateConverter() : base(
        d => d.ToString("yyyy-MM-dd"),
        s => DateOnly.Parse(s))
    { }
}
public class DateTimeConverter:ValueConverter<TimeOnly, string>
{
    public DateTimeConverter() : base(
        t => t.ToString("HH:mm:ss.fffffff"),
        s => TimeOnly.Parse(s))
    { }
}